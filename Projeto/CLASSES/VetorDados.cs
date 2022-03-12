using System;
using System.IO;
using System.Windows.Forms;

public enum Situacao
{
    navegando, incluindo, pesquisando, editando, excluindo
}

public class VetorDados<Registro> : IVetorDados<Registro> where Registro : IComparable<Registro>, IRegistro, new()
{
    Registro[] dados;
    int qtosDados;
    int posicaoAtual;

    Situacao situacaoAtual;

    public VetorDados(int tamanhoMaximo)
    {
        dados = new Registro[tamanhoMaximo];    // a aplicação define o tamanho físico do vetor
        qtosDados = 0;                          // nenhuma posição usada ainda no vetor
        PosicaoAtual = -1;                      // não está posicionada em nenhum lugar do vetor
        situacaoAtual = Situacao.navegando;
    }

    private void RedimensioneSe(int novaCap)
    {
        Registro[] novo = new Registro[novaCap];

        for (int i = 0; i < qtosDados; i++)
            novo[i] = this.dados[i];

        this.dados = novo;
    }

    public Registro[] Dados
    {
        get => this.dados;
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

    public Registro ValorDe(int posicao)
    {
        if (posicao < 0 || posicao >= qtosDados)  // fora do intervalo válido dos índices
        {
            throw new Exception("Acesso a posição inválida de armazenamento de dados");
        }

        return dados[posicao];
    }
    public void Incluir(Registro novo)  // inclui um novo registro de funcionário no final do vetor
    {
        if (this.qtosDados == this.dados.Length)
            this.RedimensioneSe(2 * this.dados.Length);

        PosicaoAtual = qtosDados;
        dados[qtosDados] = novo;
        qtosDados++;
    }

    public void Incluir(Registro novoValor, int posicaoDeInclusao)
    {
        if (this.qtosDados == this.dados.Length)
            this.RedimensioneSe(2 * this.dados.Length);

        for (int indice = qtosDados; indice > posicaoDeInclusao; indice--)
        {
            dados[indice] = dados[indice - 1];
        }

        dados[posicaoDeInclusao] = novoValor;
        qtosDados++;
    }

    public void Ordenar()
    {
        for (int lento = 0; lento < qtosDados - 1; lento++)
        {
            for (int rapido = lento + 1; rapido < qtosDados; rapido++)
            {
                if (dados[lento].CompareTo(dados[rapido]) > 0)
                {
                    Registro auxiliar = dados[lento];
                    dados[lento] = dados[rapido];
                    dados[rapido] = auxiliar;
                }
            }
        }
    }

    public void Excluir(int posicao)
    {
        if (posicao < 0 || posicao > qtosDados - 1)
        {
            throw new Exception("Índice fora dos limites!");
        }


        for (int indice = posicao; indice < qtosDados; indice++)
        {
            dados[indice] = dados[indice + 1];
        }

        qtosDados--;

        if (posicaoAtual >= qtosDados)
        {
            posicaoAtual = qtosDados - 1; // reposiocna o índice do registro atualmente visitado para
                                          // ficar na posição final em uso do vetor
        }
    }

    public bool ExisteNaoOrdenado(Registro registroProcurado, out int ondeEsta)
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

    public bool ExisteSequencialOrdenado(Registro registroProcurado, out int onde)
    {
        bool fim, achou;
        onde = 0; // inicializa variáveis de controle da pesquisa
        achou = false;
        fim = false;
        while (!achou && !fim) // not (achou or fim) // De Morgan
        {
            if (onde >= qtosDados) // condição i
            {
                fim = true;
            }
            else
            {
                if (dados[onde].CompareTo(registroProcurado) == 0)
                {
                    achou = true; // condição ii
                }
                else
                {
                    if (dados[onde].CompareTo(registroProcurado) > 0)
                    {
                        fim = true; // condição iii
                    }
                    else
                    {
                        onde++; // como nenhuma das condições foi
                                // satisfeita, acessa o elemento
                                // seguinte no vetor.
                    }
                }
            }
        }
        return achou;
    }

    public bool Existe(Registro registroProcurado, out int meio)
    {
        meio = 0;
        int inicio = 0;
        int fim = qtosDados - 1;
        bool achou = false;
        while (!achou && inicio <= fim)
        {
            meio = (inicio + fim) / 2;
            if (dados[meio].CompareTo(registroProcurado) == 0)
            {
                achou = true;
            }
            else
            {
                if (registroProcurado.CompareTo(dados[meio]) < 0)
                {
                    fim = meio - 1;
                }
                else
                {
                    inicio = meio + 1;
                }
            }
        }
        if (!achou)         // quando o valor procurado náo existe, a posi;áo onde ele deveria estar
        {
            meio = inicio;  // num vetor ordenado, é dada pelo último valor da varável inicio. Assim,
                            // neste algoritmo, quando náo se acha o valor procurado, o parâmetro meio
                            // retorna com o índica da posiçáo onde o valor procurado deveria estar.
                            // Assim, se desejarmos incluir o valor náo encontrado, basta usar esse
                            // parâmertro onde como índice de inclusáo, e o vetor continuará ordenado
                            // com o novo valor recém-incluído nessa posição
        }
        return achou;
    }

    public void PosicionarNoPrimeiro()
    {
        if (!EstaVazio)
        {
            posicaoAtual = 0; // primeira posição do vetor em uso
        }
        else
        {
            posicaoAtual = -1; // indica antes do vetor vazio
        }
    }

    public void PosicionarNoUltimo()
    {
        if (!EstaVazio)
        {
            posicaoAtual = qtosDados - 1; // última posição usada do vetor
        }
        else
        {
            posicaoAtual = -1; // indica antes do vetor vazio
        }
    }

    public void AvancarPosicao()
    {
        if (posicaoAtual < qtosDados - 1)
        {
            posicaoAtual++;
        }
    }

    public void RetrocederPosicao()
    {
        if (posicaoAtual > 0)
        {
            posicaoAtual--;
        }
    }

    public void ExibirDados()
    {
        Console.Clear();
        for (int i = 0; i < qtosDados; i++)
        {
            Console.WriteLine(dados[i].ToString());
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

    public void ExibirDados(TextBox lista)
    {
        lista.Clear();
        lista.Multiline = true;
        for (int i = 0; i < qtosDados; i++)
        {
            lista.AppendText(dados[i].ToString() + Environment.NewLine);
        }
    }

    public void ExibirDados(DataGridView grade)
    {
        if (qtosDados > 0)
        {
            grade.RowCount = qtosDados;
            for (int indice = 0; indice < qtosDados; indice++)
            {
                grade[0, indice].Value = dados[indice].ToString();
            }
        }
    }

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
            Registro dadoLido = new Registro();
            dadoLido.LerRegistro(arquivo, grafo);
            Incluir(dadoLido);
        }
        Ordenar();
        arquivo.Close();
    }

    public void GravarDados(string nomeArquivo)
    {
        var arquivo = new StreamWriter(nomeArquivo);
        for (int indice = 0; indice < qtosDados; indice++)
        {
            arquivo.WriteLine(dados[indice].FormatoDeArquivo());
        }
        arquivo.Close();
    }

    public bool EstaNoInicio
    {
        get => posicaoAtual <= 0; // primeiro índice
    }

    public bool EstaNoFim
    {
        get => posicaoAtual >= qtosDados - 1; // último índice
    }


    // propriedade para acessar situacaoAtual para consulta e ajuste
    public Situacao SituacaoAtual
    {
        get => situacaoAtual;
        set => situacaoAtual = value;
    }

    public bool EstaVazio          // permite à aplicação saber se o vetor dados está vazio
    {
        get => qtosDados <= 0;      // se qtosDados <= 0, retorna true
    }

    public int PosicaoAtual
    {
        get => posicaoAtual;
        set
        {
            if (this.EstaVazio)
            {
                posicaoAtual = 0;
            }
            else if (value >= -1 && value < qtosDados)
            {
                posicaoAtual = value;
            }
        }
    }

    public int Tamanho { get => qtosDados; }

    public Registro this[int indice]
    {
        get
        {
            if (indice < 0 || indice >= qtosDados)
            {
                throw new IndexOutOfRangeException("Posição inválido!");
            }

            return dados[indice];
        }
        set
        {
            if (indice < 0 || indice > qtosDados)
            {
                throw new IndexOutOfRangeException("Posição inválido!");
            }

            dados[indice] = value;
        }
    }

}

