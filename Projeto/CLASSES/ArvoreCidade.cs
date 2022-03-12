using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

public class ArvoreCidade
{
    NoArvore<Cidade> raiz,       // indica o nó raiz da arvore binaria
                    atual,       // indica o nó que está sendo visitado no momento
                    antecessor;  // indica o nó ancestral daquele que está sendo visitado no momento

    int quantosNos;             // quantidade de nós que existem na arvore


    Cidade[] dados;             // Vetor que armazenara as cidades lidas do arquivo txt
    int qtosDados;              // quantidade de cidades que existem no vetor


    public ArvoreCidade()
    {
        raiz = null;
        atual = null;
        antecessor = null;
        quantosNos = 0;
        qtosDados = 0;
        dados = new Cidade[10];
    }


    // Método para busca de cidade na arvore binária através do nome da cidade
    public Cidade GetCidade(string nomeCidade)
    {
        antecessor = null;
        atual = raiz;
        while (atual != null)
        {
            // atual aponta o nó com o registro procurado, antecessor aponta seu "pai"
            if (atual.Info.NomeCidade.Trim().CompareTo(nomeCidade) == 0) 
                return atual.Info;

            antecessor = atual;
            if (nomeCidade.CompareTo(atual.Info.NomeCidade.Trim()) < 0)
                atual = atual.Esq;     // Desloca apontador para o ramo à esquerda
            else
                atual = atual.Dir;     // Desloca apontador para o ramo à direita
        }

        return null;       // Se local == null, a chave não existe
    }

    public NoArvore<Cidade> Raiz
    {
        get => raiz; set => raiz = value;
    }

    public int Nos
    {
        get => quantosNos; set => quantosNos = value;
    }

    private void AtualizaIndice(Cidade cidadeExcluida)
    {
        antecessor = null;
        atual = raiz;
        while (atual != null)
        {
            if (atual.Info.Indice.CompareTo(cidadeExcluida.Indice) > 0) // atual aponta o nó com o registro procurado, antecessor aponta seu "pai"
                atual.Info.Indice--;

            antecessor = atual;
            if (cidadeExcluida.CompareTo(atual.Info) < 0)
                atual = atual.Esq;     // Desloca apontador para o ramo à esquerda
            else
                atual = atual.Dir;     // Desloca apontador para o ramo à direita
        }
    }
    public NoArvore<Cidade> Atual { get => atual; set => atual = value; }

    public void LerDados(string nomeArquivo, Grafo grafo)
    {
        if (!File.Exists(nomeArquivo))
        {
            var f = File.CreateText(nomeArquivo);
            f.Close();
        }
        qtosDados = 0;
        var arquivo = new StreamReader(nomeArquivo);
        while (!arquivo.EndOfStream)
        {
            Cidade dadoLido = new Cidade();
            dadoLido.LerRegistro(arquivo, grafo);
            dadoLido.Indice = qtosDados;
            grafo.NovoVertice(dadoLido.NomeCidade.Trim());
            IncluirVetor(dadoLido);
        }
        Ordenar();
        arquivo.Close();
    }

    public void IncluirNo(Cidade dadoLido)
    {
        dadoLido.Indice = Nos;
        for (int indice = qtosDados; indice > Nos; indice--)
        {
            dados[indice] = dados[indice - 1];
        }

        dados[Nos] = dadoLido;
        qtosDados++;

        IncluirNo(ref raiz, dadoLido);
    }

    private void IncluirNo(ref NoArvore<Cidade> atual, Cidade dadoLido)
    {
        if (atual == null)
        {
            atual = new NoArvore<Cidade>(dadoLido);
        }
        else
            if (dadoLido.CompareTo(atual.Info) == 0)
            throw new Exception("Já existe esse registro!");
        else
            if (dadoLido.CompareTo(atual.Info) > 0)
        {
            NoArvore<Cidade> apDireito = atual.Dir;
            IncluirNo(ref apDireito, dadoLido);
            atual.Dir = apDireito;
        }
        else
        {
            NoArvore<Cidade> apEsquerdo = atual.Esq;
            IncluirNo(ref apEsquerdo, dadoLido);
            atual.Esq = apEsquerdo;
        }
    }

    public bool Existe(Cidade procurado)
    {
        antecessor = null;
        atual = raiz;
        while (atual != null)
        {
            if (atual.Info.CompareTo(procurado) == 0) // atual aponta o nó com o registro procurado, antecessor aponta seu "pai"
                return true;

            antecessor = atual;
            if (procurado.CompareTo(atual.Info) < 0)
                atual = atual.Esq;     // Desloca apontador para o ramo à esquerda
            else
                atual = atual.Dir;     // Desloca apontador para o ramo à direita
        }
        return false;       // Se local == null, a chave não existe
    }

    public bool ExisteNaoOrdenado(Cidade registroProcurado, out int ondeEsta)
    {
        bool achou = false;
        ondeEsta = 0;
        while (!achou && ondeEsta < qtosDados)
        {
            if (dados[ondeEsta].CompareTo(registroProcurado) == 0)
            {
                achou = true;
            }
            else
            {
                ondeEsta++;
            }
        }
        return achou;
    }

    public void IncluirVetor(Cidade novo)
    {
        if (this.qtosDados == this.dados.Length)
            this.RedimensioneSe(2 * this.dados.Length);

        dados[qtosDados] = novo;
        qtosDados++;
    }

    public void Incluir(Cidade novoValor, int posicaoDeInclusao)
    {
        if (this.qtosDados == this.dados.Length)
            this.RedimensioneSe(2 * this.dados.Length);

        for (int indice = qtosDados; indice > posicaoDeInclusao; indice--)
        {
            dados[indice] = dados[indice - 1];
        }

        novoValor.Indice = qtosDados;
        dados[posicaoDeInclusao] = novoValor;
        qtosDados++;
    }

    private void RedimensioneSe(int novaCap)
    {
        Cidade[] novo = new Cidade[novaCap];
        for (int i = 0; i < qtosDados; i++)
            novo[i] = this.dados[i];

        this.dados = novo;
    }

    private void Ordenar()
    {
        for (int lento = 0; lento < qtosDados - 1; lento++)
        {
            for (int rapido = lento + 1; rapido < qtosDados; rapido++)
            {
                if (dados[lento].CompareTo(dados[rapido]) > 0)
                {
                    Cidade auxiliar = dados[lento];
                    dados[lento] = dados[rapido];
                    dados[rapido] = auxiliar;
                }
            }
        }
    }

    public void ExibirDados(ListBox lista)
    {
        lista.Items.Clear();
        for (int i = 0; i < qtosDados; i++)
        {
            lista.Items.Add(dados[i].ToString());
        }
    }

    public void ExibirDados(ComboBox lista)
    {
        lista.Items.Clear();
        for (int i = 0; i < qtosDados; i++)
        {
            lista.Items.Add(dados[i].ToString());
        }
    }

    public void InserirBalanceado()
    {
        raiz = null;
        Cidade dado;
        Particionar(0, qtosDados - 1, ref raiz);

        void Particionar(long inicio, long fim, ref NoArvore<Cidade> atual)
        {
            if (inicio <= fim)
            {
                long meio = (inicio + fim) / 2;

                dado = new Cidade();       // cria um objeto para armazenar os dados
                dado = dados[(int)meio];
                atual = new NoArvore<Cidade>(dado);
                var novoEsq = atual.Esq;
                Particionar(inicio, meio - 1, ref novoEsq);     // Particiona à esquerda 
                atual.Esq = novoEsq;
                var novoDir = atual.Dir;
                Particionar(meio + 1, fim, ref novoDir);        // Particiona à direita
                atual.Dir = novoDir;
            }
        }

        Nos = QtosNos(raiz);
    }

    private int QtosNos(NoArvore<Cidade> noAtual)
    {
        if (noAtual == null)  // árvore vazia ou descendente de folha
            return 0;

        return 1 +                 // conta o nó atual
            QtosNos(noAtual.Esq) + // conta nós da subárvore esquerda
            QtosNos(noAtual.Dir);  // conta nós da subárvore direita
    }

    public bool ApagarNo(Cidade registroARemover)
    {
        // Apaga essa cidade do vetor
        for (int indice = registroARemover.Indice; indice < qtosDados; indice++)
        {
            dados[indice] = dados[indice + 1];
        }
        qtosDados--;

        atual = raiz;
        antecessor = null;
        bool ehFilhoEsquerdo = true;

        // Enquanto não acha a chave a remover
        while (atual.Info.CompareTo(registroARemover) != 0)  
        {
            antecessor = atual;
            if (atual.Info.CompareTo(registroARemover) > 0)
            {
                ehFilhoEsquerdo = true;
                atual = atual.Esq;
            }
            else
            {
                ehFilhoEsquerdo = false;
                atual = atual.Dir;
            }

            if (atual == null)  // neste caso, a chave a remover não existe e não pode
                return false;   // ser excluída, dai retornamos falso indicando isso
        }  // fim do while

        // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
        // e o ponteiro atual indica o nó que contém essa chave

        if ((atual.Esq == null) && (atual.Dir == null))  // é folha, nó com 0 filhos
        {
            if (atual == raiz)
                raiz = null;   // exclui a raiz e a árvore fica vazia
            else
                if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixará 
                antecessor.Esq = null;  // de ter um descendente esquerdo
            else                        // se for filho direito, o antecessor deixará de 
                antecessor.Dir = null;  // apontar para esse filho

            atual = antecessor;  // feito para atual apontar um nó válido ao sairmos do método
        }
        else   // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
            if (atual.Dir == null)   // neste caso, só tem o filho esquerdo
        {
            if (atual == raiz)
                raiz = atual.Esq;
            else
                if (ehFilhoEsquerdo)
                antecessor.Esq = atual.Esq;
            else
                antecessor.Dir = atual.Esq;
            atual = antecessor;
        }
        else
                if (atual.Esq == null)  // neste caso, só tem o filho direito
        {
            if (atual == raiz)
                raiz = atual.Dir;
            else
                if (ehFilhoEsquerdo)
                antecessor.Esq = atual.Dir;
            else
                antecessor.Dir = atual.Dir;
            atual = antecessor;
        }
        else // tem os dois descendentes
        {
            NoArvore<Cidade> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
            atual.Info = menorDosMaiores.Info;
            menorDosMaiores = null; // para liberar o nó trocado da memória
        }
        AtualizaIndice(registroARemover);
        return true;
    }

    public NoArvore<Cidade> ProcuraMenorDosMaioresDescendentes(NoArvore<Cidade> noAExcluir)
    {
        NoArvore<Cidade> paiDoSucessor = noAExcluir;
        NoArvore<Cidade> sucessor = noAExcluir;
        NoArvore<Cidade> atual = noAExcluir.Dir;   // vai ao ramo direito do nó a ser excluído, pois este ramo contém
                                                    // os descendentes que são maiores que o nó a ser excluído 


        while (atual != null)
        {
            if (atual.Esq != null)
                paiDoSucessor = atual;
            sucessor = atual;
            atual = atual.Esq;
        }

        if (sucessor != noAExcluir.Dir)
        {
            paiDoSucessor.Esq = sucessor.Dir;
            sucessor.Dir = noAExcluir.Dir;
        }
        else
        {
            sucessor.Esq = sucessor.Dir;
            paiDoSucessor.Dir = sucessor.Dir;
        }

        return sucessor;
    }


    public void GravacaoEmDisco(string nomeArquivo)
    {
        var arqDados = new StreamWriter(nomeArquivo);
        for (int i = 0; i < qtosDados; i++)
        {
            arqDados.WriteLine(dados[i].FormatoDeArquivo());
        }
        arqDados.Close();
    }

    public void DesenharArvore(bool primeiraVez, NoArvore<Cidade> raiz, int x, int y, double angulo, double incremento, double comprimento, Graphics g)
    {
        int xf, yf;
        if (raiz != null)
        {
            Pen caneta = new Pen(Color.Red);
            xf = (int)Math.Round(x + Math.Cos(angulo) * comprimento);
            yf = (int)Math.Round(y + Math.Sin(angulo) * comprimento);

            if (primeiraVez)
                yf = 25;

            g.DrawLine(caneta, x, y, xf, yf);
            DesenharArvore(false, raiz.Esq, xf, yf, Math.PI / 2 + incremento,
                                                   incremento * 0.65, comprimento * 0.80, g);
            DesenharArvore(false, raiz.Dir, xf, yf, Math.PI / 2 - incremento,
                                    incremento * 0.65, comprimento * 0.80, g);
            SolidBrush preenchimento = new SolidBrush(Color.MediumAquamarine);
            g.FillEllipse(preenchimento, xf - 25, yf - 15, 42, 30);
            g.DrawString(Convert.ToString(raiz.Info.ToString()),
                            new Font("Comic Sans", 10),
                            new SolidBrush(Color.Black), xf - 23, yf - 7);
        }
    }

    public void DesenharCaminho(int[] pos, PictureBox pbMapa)
    {
        pbMapa.Refresh();
        int qtdPos      = 0;
        int qtdCidades  = 0;

        Cidade cidade1, cidade2;
        Graphics g = pbMapa.CreateGraphics();


        double xf, yf, x, y;
        
        double antX = 0;
        double antY = 0;

        foreach (int elements in pos)
        {
            if (elements != -1)
                qtdCidades++;
        }

        int posCidade;

        for (int i = 0; i < qtdCidades - 1; i++)
        {
            if (i == 0)
            {
                posCidade = pos[qtdPos++];
                cidade1 = dados[posCidade];
                x = cidade1.CoordenadaX;
                y = cidade1.CoordenadaY;
            }
            else
            {
                x = antX;
                y = antY;
            }

            posCidade = pos[qtdPos++];
            cidade2 = dados[posCidade];
            xf = cidade2.CoordenadaX;
            yf = cidade2.CoordenadaY;

            if (i == qtdCidades - 1)
            {
                yf = antY;
                xf = antX;
            }
            else
            {
                antX = xf;
                antY = yf;
            }

        
            // Ajusta as coordenadas de acordo com o tamanho do forms
            x = x * pbMapa.Size.Width;
            y = y * pbMapa.Size.Height;
            xf = xf * pbMapa.Size.Width;
            yf = yf * pbMapa.Size.Height;

            // Desenha a ligação dessas duas cidades
            Pen caneta = new Pen(Color.DarkGreen);
            caneta.Width = 4;  
            g.DrawLine(caneta, Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(xf), Convert.ToInt32(yf));
        }
    }
}
