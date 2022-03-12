using System;
using System.Collections.Generic;
using System.Text;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

public class InfoRota
{
    int preco;
    int distancia;

    public InfoRota()
    {
        distancia = 1000000;
    }

    public InfoRota(int preco, int distancia)
    {
        this.preco = preco;
        this.distancia = distancia;
    }

    public int Preco
    {
        get => preco;
        set
        {
            if (value > 0)
                preco = value;
            else
                throw new Exception("preco inválido");
        }
    }


    public int Distancia 
    {
        get => distancia;
        set
        {
            if (value > 0)
                distancia = value;
            else
                throw new Exception("distancia inválida");
        }
    }
}

