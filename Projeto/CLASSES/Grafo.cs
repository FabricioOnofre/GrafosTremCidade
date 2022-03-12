using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// Fabricio Onofre Rezende de Camargo  - RA:20130
// Ligia Keiko Carvalho                - RA:20143

public class Grafo
{
    private const int NUM_VERTICES = 100;
    private VetorDados<Vertice> vertices;
    private InfoRota[,] adjMatrix;
    int numVerts;
    DataGridView dgv;   // para exibir a matriz de adjacência num formulário
    PictureBox picBox;

    /// DJIKSTRA
    DistOriginal[] percurso;
    int infinity = 1000000;
    int verticeAtual;   // global usada para indicar o vértice atualmente sendo visitado 
    int doInicioAteAtual;   // global usada para ajustar menor caminho com Djikstra
    int preco;
    int nTree;

    public VetorDados<Vertice> Vertices { get => vertices; set => vertices = value; }

    public Grafo()
    {
        vertices = new VetorDados<Vertice>(NUM_VERTICES);
        adjMatrix = new InfoRota[NUM_VERTICES, NUM_VERTICES];
        numVerts = 0;
        nTree = 0;

        for (int j = 0; j < NUM_VERTICES; j++)      // zera toda a matriz
            for (int k = 0; k < NUM_VERTICES; k++)
                adjMatrix[j, k] = new InfoRota();   // distância tão grande que não existe

        percurso = new DistOriginal[NUM_VERTICES];
    }

    public bool Caminho(int inicioDoPercurso, int finalDoPercurso, ListBox lista, ref int[] pos)
    {
        // Todas cidades serão verificadas novamente
        for (int j = 0; j < numVerts; j++)
            vertices[j].FoiVisitado = false;

        // Cidade de origem já foi visitada, pois é o inicio do percurso
        vertices[inicioDoPercurso].FoiVisitado = true;

        for (int j = 0; j < numVerts; j++)
        {
            // anotamos no vetor percurso as informações entre o inicioDoPercurso e cada vértice
            // se não há ligação direta, a informação distância será infinity
            InfoRota tempDist = adjMatrix[inicioDoPercurso, j];
            percurso[j] = new DistOriginal(inicioDoPercurso, tempDist);
        }

        for (int nTree = 0; nTree < numVerts; nTree++)
        {
            // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
            int indiceDoMenor = ObterMenor();

            // e anotamos essa menor distância
            int distanciaMinima = percurso[indiceDoMenor].infoRota.Distancia;


            // o vértice com a menor distância passa a ser o vértice atual
            // para compararmos com a distância calculada em AjustarMenorCaminho()
            verticeAtual = indiceDoMenor;
            doInicioAteAtual = percurso[indiceDoMenor].infoRota.Distancia;
            preco = percurso[indiceDoMenor].infoRota.Preco;


            // visitamos o vértice com a menor distância desde o inicioDoPercurso
            vertices[verticeAtual].FoiVisitado = true;
            AjustarMenorCaminho();
        }

        return ExibirPercursos(inicioDoPercurso, finalDoPercurso, lista, ref pos);
    }

    public void AjustarMenorCaminho()
    {
        for (int coluna = 0; coluna < numVerts; coluna++)
        {
            if (!vertices[coluna].FoiVisitado)       // para cada vértice ainda não visitado
            {
                // acessamos a distância desde o vértice atual (pode ser infinity)
                int atualAteMargem = adjMatrix[verticeAtual, coluna].Distancia;
                int precoAteMargem = adjMatrix[verticeAtual, coluna].Preco;
                // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                // esta saída
                int doInicioAteMargem = doInicioAteAtual + atualAteMargem;
                int precoFinal = preco + precoAteMargem;
                // quando encontra uma distância menor, marca o vértice a partir do
                // qual chegamos no vértice de índice coluna, e a soma da distância
                // percorrida para nele chegar
                int distanciaDoCaminho = percurso[coluna].infoRota.Distancia;


                if (doInicioAteMargem <= distanciaDoCaminho)
                {
                    percurso[coluna].verticePai = verticeAtual;
                    percurso[coluna].infoRota.Distancia = doInicioAteMargem;
                    percurso[coluna].infoRota.Preco = precoFinal;
                }
            }
        }
    }

    public bool ExibirPercursos(int inicioDoPercurso, int finalDoPercurso, ListBox lista, ref int[] pos)
    {

        string resultado = "";       
        
        Stack<string> pilha = new Stack<string>();
        int[] cidade = new int[vertices.Tamanho];

        
        int onde = finalDoPercurso;
        int qtdCidades = 0, cont = 0;
        

        int preco       = percurso[onde].infoRota.Preco;
        int distancia   = percurso[onde].infoRota.Distancia;

        int hora = distancia / 200;
        double min = ((double)distancia % 200 / (double)200) * 60;
        string tempo = hora + " hrs " + (int)min + " min";

        for (int i = 0; i < cidade.Length; i++)
        {
            cidade[i] = -1;
        }

        cidade[qtdCidades++] = finalDoPercurso;
        while (onde != inicioDoPercurso)
        {
            onde = percurso[onde].verticePai;
            cidade[qtdCidades++] = onde;
            pilha.Push(vertices[onde].Rotulo);
            cont++;
        }

        pos = cidade;
        string cidades = "";

        int aux = 0;
        while (pilha.Count != 0)
        {
            resultado += pilha.Pop();

            if (pilha.Count != 0)
                resultado += " --> ";

            if (aux % 10 == 0 && aux > 0)
            {
                cidades = resultado;
                resultado = "";
            }
            aux++;


        }

        if ((cont == 1) && (percurso[finalDoPercurso].infoRota.Distancia == infinity))
            return false;
        else
        {
            
            lista.Items.Add("Distância     : " + distancia + " km");
            lista.Items.Add("Tempo estimado: " + tempo);
            lista.Items.Add("Preço    (€$) : " + preco + ",00");
            lista.Items.Add("");
            lista.Items.Add("Caminho entre " + vertices[inicioDoPercurso].Rotulo +" e " + vertices[finalDoPercurso].Rotulo);
            lista.Items.Add(cidades);

            resultado += " --> " + vertices[finalDoPercurso].Rotulo;
            lista.Items.Add(resultado);
            return true;
        }



    }

    public void NovoVertice(string label)
    {
        vertices.Incluir(new Vertice(label));

        numVerts++;
    }

    public int GetVerticePosicao(string nomeVertice)
    {
        int pos;
        for (pos = 0; pos < numVerts - 1; pos++)
            if (nomeVertice.Equals(vertices[pos].Rotulo))
                break;
        return pos;
    }

    public void NovaAresta(int origem, int destino, InfoRota peso)
    {
        adjMatrix[origem, destino] = peso;
    }


    public void RemoverVertice(int vert)
    {
        if (vert != numVerts - 1)
        {
            for (int j = vert; j < numVerts - 1; j++)   // remove vértice do vetor
                vertices[j] = vertices[j + 1];

            // remove vértice da matriz
            for (int row = vert; row < numVerts; row++)
                moverLinhas(row, numVerts - 1);
            for (int col = vert; col < numVerts; col++)
                moverColunas(col, numVerts - 1);
        }
        numVerts--;
    }

    private void moverLinhas(int row, int length)
    {
        if (row != numVerts - 1)
            for (int col = 0; col < length; col++)
                adjMatrix[row, col] = adjMatrix[row + 1, col];  // desloca para excluir
    }

    private void moverColunas(int col, int length)
    {
        if (col != numVerts - 1)
            for (int row = 0; row < length; row++)
                adjMatrix[row, col] = adjMatrix[row, col + 1]; // desloca para excluir
    }



    public void PercursoEmProfundidadeRec(int[,] adjMatrix, int numVerts, int part, TextBox txt)
    {
        int i;
        vertices[part].FoiVisitado = true;
        for (i = 0; i < numVerts; ++i)
            if (adjMatrix[part, i] != infinity && !vertices[i].FoiVisitado)
                PercursoEmProfundidadeRec(adjMatrix, numVerts, i, txt);
    }

    public int ObterMenor()
    {
        int distanciaMinima = infinity;
        int indiceDaMinima = 0;
        for (int j = 0; j < numVerts; j++)
            if (!(vertices[j].FoiVisitado) && (percurso[j].infoRota.Distancia < distanciaMinima))
            {
                distanciaMinima = percurso[j].infoRota.Distancia;
                indiceDaMinima = j;
            }
        return indiceDaMinima;
    }
}
