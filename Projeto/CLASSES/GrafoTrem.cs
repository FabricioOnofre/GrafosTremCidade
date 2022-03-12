using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

public class GrafoTrem : IComparable<GrafoTrem>, IRegistro
{
    const int tamanhoCidade1    = 15;
    const int tamanhoCidade2    = 16;
    const int tamanhoDistancia  = 5;

    const int inicioCidade1 = 0;
    const int inicioCidade2 = inicioCidade1 + tamanhoCidade1;
    const int inicioDistancia = inicioCidade2 + tamanhoCidade2;
    const int inicioPreco = inicioDistancia + tamanhoDistancia;

    string primeiraCidade;
    string segundaCidade;
    int preco;
    int distancia;

    public GrafoTrem()  // para que esta classe seja compatível com a interface IVetorDados e a classe genérica Registro
    {

    }

    public GrafoTrem(string cidade1, string cidade2, int dist, int preco)
    {
        PrimeiraCidade = cidade1;
        SegundaCidade  = cidade2;
        Distancia = dist;
        Preco = preco;
    }

    public string PrimeiraCidade
    {
        get => primeiraCidade;
        set
        {
            if (value.Length > tamanhoCidade1)
            {
                value = value.Substring(0, tamanhoCidade1);
            }
            primeiraCidade = value.PadRight(tamanhoCidade1, ' ');
        }
    }

    public string SegundaCidade
    {
        get => segundaCidade;
        set
        {
            if (value.Length > tamanhoCidade2)
            {
                value = value.Substring(0, tamanhoCidade2);
            }
            segundaCidade = value.PadRight(tamanhoCidade2, ' ');
        }
    }

    public int Distancia
    {
        get => distancia;
        set
        {
            if (value >= 0)
            {
                distancia = value;
            }
        }
    }

    public int Preco
    {
        get => preco;
        set
        {
            if (value >= 0)
            {
                preco = value;
            }
        }
    }

    public int CompareTo(GrafoTrem outro)
    {

        if (PrimeiraCidade.CompareTo(outro.PrimeiraCidade) == 0)
        {
            if (SegundaCidade.CompareTo(outro.SegundaCidade) == 0)
            {
                return 0;                        
            }
            else if (SegundaCidade.CompareTo(outro.SegundaCidade) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        else if (PrimeiraCidade.CompareTo(outro.PrimeiraCidade) < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public string FormatoDeArquivo()
    {

        string saida = PrimeiraCidade + SegundaCidade + Distancia.ToString().PadRight(tamanhoDistancia, ' ') + Preco;

        return saida;
    }

    public void LerRegistro(StreamReader arq, Grafo grafo)
    {
        if (!arq.EndOfStream)
        {

            String linha = arq.ReadLine();
            PrimeiraCidade = linha.Substring(inicioCidade1, tamanhoCidade1);
            SegundaCidade = linha.Substring(inicioCidade2, tamanhoCidade2);
            Distancia = int.Parse(linha.Substring(inicioDistancia, tamanhoDistancia));
            Preco = int.Parse(linha.Substring(inicioPreco));

            // É criada uma ligação de ida e volta na matriz de adjacências do grafo
            grafo.NovaAresta(grafo.GetVerticePosicao(PrimeiraCidade.Trim()),
                                grafo.GetVerticePosicao(SegundaCidade.Trim()), new InfoRota(Preco, Distancia));
            grafo.NovaAresta(grafo.GetVerticePosicao(SegundaCidade.Trim()),
                    grafo.GetVerticePosicao(PrimeiraCidade.Trim()), new InfoRota(Preco, Distancia));
        }
    }

    public override String ToString()
    {
        string saida = PrimeiraCidade.Trim() + " " + SegundaCidade.Trim() + " " + Distancia + " " + Preco;
        return saida;
    }
}

