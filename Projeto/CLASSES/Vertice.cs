using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

public class Vertice : IComparable<Vertice>, IRegistro
{
    private bool foiVisitado;
    private string rotulo;
    private bool estaAtivo;

    public bool FoiVisitado { get => foiVisitado; set => foiVisitado = value; }
    public string Rotulo { get => rotulo; set => rotulo = value; }
    public bool EstaAtivo { get => estaAtivo; set => estaAtivo = value; }

    public Vertice() { }
    public Vertice(string label)
    {
        Rotulo = label;
        FoiVisitado = false;
        estaAtivo = true;
    }

    public int CompareTo(Vertice other)
    {
        return Rotulo.CompareTo(other.Rotulo);
    }

    public void LerRegistro(StreamReader arq, Grafo grafo)
    {
        throw new NotImplementedException();
    }

    public string FormatoDeArquivo()
    {
        throw new NotImplementedException();
    }
}

