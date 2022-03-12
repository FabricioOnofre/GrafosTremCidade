using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

namespace Grafos
{
    public partial class FrmGrafo : Form
    {
        public FrmGrafo()
        {
            InitializeComponent();
        }

        // Endereço dos arquivos.txt
        string arqGrafoTrem;
        string arqCidades;

        
        VetorDados<GrafoTrem> asRotas; // Vetor que armazenara as informações sobre as rotas cadastradas
        Grafo grafo;                   // Objeto que conterá a matriz de adjacências, representando o grafo
        ArvoreCidade arvore;           // Arvore binária que guardará as cidades cadastradas



        bool erroLeitura = false;      
        // Método para a leitura dos arquivos txt, após o formulário ser aberto
        private void FrmGrafo_Load_1(object sender, EventArgs e)
        {

          
            grafo = new Grafo();
            
            openFile.Title = "Selecione o arquivo de cidades";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   
                    arqCidades = openFile.FileName;                                                            
                    arvore = new ArvoreCidade();

                    // Gera o vetor de cidades, cuja as posições serão usadas na arvore binaria balanceada
                    // Além de adicionar os vertices do grafo
                    arvore.LerDados(arqCidades, grafo);                   
                    arvore.InserirBalanceado();

                    // Exibi as cidades atualizadas na tela
                    MostrarCidades();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir arquivo.\n" + ex.Message);
                    erroLeitura = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Problema ao abrir arquivo.\n");
                erroLeitura = true;
                Close();
            }

            openFile.Title = "Selecione o arquivo de rota dos trens Espanha e Portugal";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    arqGrafoTrem = openFile.FileName;

                    asRotas = new VetorDados<GrafoTrem>(30);

                    // Gera o vetor que armazenara as rotas entre cidades
                    // Além de montar a matriz de adjacências do grafo
                    asRotas.LerDados(arqGrafoTrem, grafo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir arquivo.\n" + ex.Message);
                    erroLeitura = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Problema ao abrir arquivo.\n");
                erroLeitura = true;
                Close();
            }
        }
      

        int[] posCidade;
        // Método para a busca de roteiro entre uma cidade A e uma cidade B
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lvResultados.Items.Clear();
            string de = cbDe.Text.TrimEnd().TrimStart();
            string para = cbPara.Text.TrimEnd().TrimStart();

            Cidade cidadeTeste;
            
            
            // Se conseguiu converter todos os campos de digitação adequadamente
            if (!String.IsNullOrEmpty(de) && !String.IsNullOrWhiteSpace(de))
            {
                if (arvore.GetCidade(de) != null)
                {
                    if (!String.IsNullOrEmpty(para) && !String.IsNullOrWhiteSpace(para))
                    {
                        if (arvore.GetCidade(para) != null)
                        {
                            if (!de.Equals(para))
                            {
                                // É feita a busca do caminho entre as cidades
                                // Caso um caminho exista o método Caminho retorna true, caso contrário false
                                bool result = grafo.Caminho(grafo.GetVerticePosicao(de), grafo.GetVerticePosicao(para),
                                            lvResultados, ref posCidade);

                                // Caso ache um caminho entre as cidades desejadas
                                // O caminho entre elas é desenhado no mapa
                                if (result)
                                {
                                    arvore.DesenharCaminho(posCidade, pbMapa);
                                }
                                else
                                {
                                    // Caso não ache um caminho entre as cidades desejadas
                                    // Os dados do caminho anterior são limpados da tela                                  
                                    pbMapa.Refresh();
                                    lvResultados.Items.Clear();
                                    MessageBox.Show("Não há caminho entre " + de + " e " + para);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cidade de origem e destino são iguais. Por favor, selecione duas cidades distintas!");
                            }
                        }
                        else
                            MessageBox.Show("Cidade de destino inexistente. Por favor, digite outra cidade!");
                    }
                    else
                    {
                        MessageBox.Show("Cidade de destino inválida. Por favor, digite corretamente!");
                    }
                }
                else 
                    MessageBox.Show("Cidade de origem inexistente. Por favor, digite outra cidade!");
            }
            else
            {
                MessageBox.Show("Cidade de origem inválida. Por favor, digite corretamente!");
            }
        }


        // Método para a exibição da arvore binaria de cidades
        private void pnlArvore_Paint(object sender, PaintEventArgs e)
        {
            // A arvore é desenhada, caso ela existe
            if (arvore != null)
            {
                Graphics g = e.Graphics;
                arvore.DesenharArvore(true, arvore.Raiz, (int)pnlArvore.Width / 2, 0,
                  3 * Math.PI / 2, Math.PI / 2.5, 300, g);
            }
        }

        // Método para a reexibição do caminho entre cidades, caso o usuario redimensione o tamanho do formulário
        private void FrmGrafo_Resize(object sender, EventArgs e)
        {
            // O caminho é desenhado, caso ele existe
            if (posCidade != null)
            {
                arvore.DesenharCaminho(posCidade, pbMapa);
            }
        }

        // Método para exclusão de uma cidade na arvore binaria
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string cidade = cbCidadeExcluir.Text.TrimEnd().TrimStart();

            // Se conseguiu converter todos os campos de digitação adequadamente
            if (!String.IsNullOrEmpty(cidade) && !String.IsNullOrWhiteSpace(cidade))
            {
                Cidade cidadeExcluida = arvore.GetCidade(cidade);


                if (cidadeExcluida != null)
                {
                    arvore.ApagarNo(cidadeExcluida);             // Essa cidade é excluida da arvore binaria
                    grafo.RemoverVertice(cidadeExcluida.Indice); // Exclui o vertice correspondente a essa cidade
                    MostrarCidades();                            // Exibi as cidades atualizadas na tela
                    MessageBox.Show("A cidade " + cidade + " foi excluída");
                }
                else
                    MessageBox.Show("A cidade não existe");
            }
            else
                MessageBox.Show("Cidade inválida. Por favor, digite corretamente!");
        }

        // Método para inclusão de uma cidade na arvore binaria
        private void btnCadastrarCidade_Click_1(object sender, EventArgs e)
        {
            string cidade = txtNomeCidade.Text.TrimEnd().TrimStart();
            double latitude, longitude;

            // Se conseguiu converter todos os campos de digitação adequadamente
            if (!String.IsNullOrEmpty(cidade) && !String.IsNullOrWhiteSpace(cidade))
            {
                if (numLatitude.Value > 0)
                {
                    latitude = (double)numLatitude.Value;
                    if (numLongitude.Value > 0)
                    {
                        longitude = (double)numLongitude.Value;
                        var novaCidade = new Cidade(cidade, latitude, longitude);

                        if (arvore.Existe(novaCidade)) // Cidade já está cadastrada?
                        {
                            MessageBox.Show("Cidade já existente. Não pode ser incluída novamente!");
                        }
                        else
                        {
                            arvore.IncluirNo(novaCidade); // Essa cidade é incluida na arvore binaria
                            grafo.NovoVertice(cidade);    // Inclui um novo vertice correspondente a essa cidade
                            MostrarCidades();             // Exibi as cidades atualizadas na tela                
                            MessageBox.Show("A cidade " + cidade + " foi incluída");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Longitude inválida. Por favor, digite corretamente!");
                    }
                }
                else
                {
                    MessageBox.Show("Latitude inválida. Por favor, digite corretamente!");
                }
            }
            else   // O campo matrícula não foi digitado corretamente
            {
                MessageBox.Show("Nome de cidade inválido. Por favor, digite corretamente!");
            }
        }

        // Método para inclusão de um roteiro entre uma cidade A e uma cidade B
        private void btnCadastrarRota_Click_1(object sender, EventArgs e)
        {
            string cidadeOrigem = cbCidadeOrigem.Text.TrimEnd().TrimStart(), cidadeDestino = cbCidadeDestino.Text.TrimEnd().TrimStart();
            int preco, distancia;

            // Se conseguiu converter todos os campos de digitação adequadamente
            if (!String.IsNullOrEmpty(cidadeOrigem) && !String.IsNullOrWhiteSpace(cidadeOrigem))
            {
               
                if (arvore.GetCidade(cidadeOrigem) != null)
                {
                    if (!String.IsNullOrEmpty(cidadeDestino) && !String.IsNullOrWhiteSpace(cidadeDestino))
                    {
                        if (arvore.GetCidade(cidadeOrigem) != null)
                        {
                            if (!cidadeDestino.Equals(cidadeOrigem))
                            {
                                if (numPreco.Value > 0)
                                {
                                    preco = (int)numPreco.Value;
                                    if (numDistancia.Value > 0)
                                    {
                                        distancia = (int)numDistancia.Value;
                                        var novaRota = new GrafoTrem(cidadeOrigem, cidadeDestino, distancia, preco);

                                        int posicaoDeInclusao = -1;
                                        if (asRotas.ExisteNaoOrdenado(novaRota, out posicaoDeInclusao)) // Rota já está cadastrada?
                                        {
                                            MessageBox.Show("Rota já existente. Não pode ser incluída novamente!");
                                            LimparDados();
                                        }
                                        else
                                        {
                                            asRotas.Incluir(novaRota, posicaoDeInclusao);    // Essa Rota é incluida no vetor de rotas

                                            // É criada uma ligação de ida e volta na matriz de adjacências do grafo
                                            grafo.NovaAresta(grafo.GetVerticePosicao(cidadeOrigem),
                                                grafo.GetVerticePosicao(cidadeDestino), new InfoRota(preco, distancia));
                                            grafo.NovaAresta(grafo.GetVerticePosicao(cidadeDestino),
                                                grafo.GetVerticePosicao(cidadeOrigem), new InfoRota(preco, distancia));


                                            MessageBox.Show($"Rota entre {cidadeOrigem} e {cidadeDestino} incluida com sucesso!");
                                            LimparDados();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Distância inválida. Por favor, digite corretamente!");
                                        numDistancia.Value = 0;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Preco inválida. Por favor, digite corretamente!");
                                    numPreco.Value = 0;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cidade de origem e destino são iguais. Por favor, escolha cidades distintas!");
                                cbCidadeDestino.Text = "";
                                cbCidadeOrigem.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cidade de destino inexistente. Por favor, digite outra cidade!");
                            cbCidadeDestino.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cidade de destino inválida. Por favor, digite corretamente!");
                        cbCidadeDestino.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Cidade de origem inexistente. Por favor, digite outra cidade!");
                    cbCidadeOrigem.Text = "";
                }
            }
            else   // O campo matrícula não foi digitado corretamente
            {
                MessageBox.Show("Cidade de origem inválida. Por favor, digite corretamente!");
                cbCidadeOrigem.Text = "";
            }
        }

        // Método para atualizar os campos de digitção da tela
        private void MostrarCidades()
        {
            arvore.ExibirDados(cbCidadeOrigem);
            arvore.ExibirDados(cbCidadeDestino);
            arvore.ExibirDados(lbCidades);
            arvore.ExibirDados(cbDe);
            arvore.ExibirDados(cbPara);
            arvore.ExibirDados(cbCidadeExcluir);
            arvore.ExibirDados(lbCidades);
        }

        // Método para limpar os campos de digitção da tela
        private void LimparDados()
        {
            cbCidadeDestino.Text    = "";
            cbCidadeExcluir.Text    = "";
            cbCidadeOrigem.Text     = "";
            cbDe.Text               = "";
            cbPara.Text             = "";
            numDistancia.Value      = 0;
            numPreco.Value          = 0;
            numLongitude.Value      = 0;
            numLatitude.Value       = 0;
        }



        // Método para a gravação das rotas e cidades atualizadas nos arquivos txt
        private void FrmGrafo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Caso não ocorreu nenhum erro de abertura dos arquivos.
            if (!erroLeitura)
            {
                arvore.GravacaoEmDisco(arqCidades);
                asRotas.GravacaoEmDisco(arqGrafoTrem);
            }
        }

    }
}
