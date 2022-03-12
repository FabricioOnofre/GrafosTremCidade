using System;

public class NoArvore<Cidade> : IComparable<NoArvore<Cidade>> where Cidade : IComparable<Cidade>
{
    Cidade info;
    NoArvore<Cidade> esq;
    NoArvore<Cidade> dir;
    int altura;
    public NoArvore(Cidade Informação)
    {
        this.Info = Informação;
        this.esq = null;
        this.dir = null;
    }
    public NoArvore(Cidade dados, NoArvore<Cidade> esquerdo, NoArvore<Cidade> direito)
    {
        this.Info = dados;
        this.Esq = esquerdo;
        this.Dir = direito;
    }
    public Cidade Info { get => info; set => info = value; }
    public NoArvore<Cidade> Esq { get => esq; set => esq = value; }
    public NoArvore<Cidade> Dir { get => dir; set => dir = value; }
    public int CompareTo(NoArvore<Cidade> o)
    {
        return info.CompareTo(o.info);
    }
    public bool Equals(NoArvore<Cidade> o)
    {
        return this.info.Equals(o.info);
    }
}
