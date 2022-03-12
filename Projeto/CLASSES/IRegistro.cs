using System;
using System.IO;

public interface IRegistro
{
    void LerRegistro(StreamReader arq, Grafo grafo);
    string FormatoDeArquivo();
    string ToString();

}