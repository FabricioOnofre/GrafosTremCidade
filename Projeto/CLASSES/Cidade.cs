using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

public class Cidade : IComparable<Cidade>, IRegistro
{

    const int tamanhoNomeCidade = 16;
    const int tamanhoCoordenadaX = 5;

    const int inicioNomeCidade = 0;
    const int inicioCoordenadaX = inicioNomeCidade + tamanhoNomeCidade;
    const int inicioCoordenadaY = inicioCoordenadaX + tamanhoCoordenadaX;

    string nomeCidade;
    double coordenadaX;
    double coordenadaY;
    int    indice;

    public Cidade() { }  // para que esta classe seja compatível com a interface IVetorDados e a classe genérica Registro{

    public Cidade(string cidade, double cordX, double cordY)
    {
        NomeCidade = cidade;
        CoordenadaX = cordX;
        coordenadaY = cordY;
    }

    public string NomeCidade
    {
        get => nomeCidade;
        set
        {
            if (value.Length > tamanhoNomeCidade)
            {
                value = value.Substring(0, tamanhoNomeCidade);
            }
            nomeCidade = value.PadRight(tamanhoNomeCidade, ' ');
        }
    }

    public int Indice
    {
        get => indice;
        set
        {
            if (value < 0)
                throw new Exception("Indice incorreto");
            else
                indice = value;
        }
    }

    public double CoordenadaX
    {
        get => coordenadaX;
        set
        {
            if (value >= 0 && value <= 9)
            {
                coordenadaX = value;
            }
        }
    }

    public double CoordenadaY
    {
        get => coordenadaY;
        set
        {
            if (value >= 0 && value <= 9)
            {
                coordenadaY = value;
            }
        }
    }

    public int CompareTo(Cidade outro)
    {
        return NomeCidade.CompareTo(outro.NomeCidade);
    }

    public string FormatoDeArquivo()
    {

        string saida = NomeCidade.ToString() + CoordenadaX.ToString().PadRight(tamanhoCoordenadaX, ' ')+ coordenadaY;

        return saida;
    }

    public void LerRegistro(StreamReader arq, Grafo grafo)
    {
        if (!arq.EndOfStream)
        {
            String linha = arq.ReadLine();
            NomeCidade = linha.Substring(inicioNomeCidade, tamanhoNomeCidade);
            CoordenadaX = double.Parse(linha.Substring(inicioCoordenadaX, tamanhoCoordenadaX));
            CoordenadaY = double.Parse(linha.Substring(inicioCoordenadaY));
        }
    }

    public override String ToString()
    {
        string saida = NomeCidade.Trim();
         
        return saida;
    }
}

