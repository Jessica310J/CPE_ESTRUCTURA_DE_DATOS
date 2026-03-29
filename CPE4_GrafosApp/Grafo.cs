using System;
using System.Collections.Generic;

class Grafo
{
    // Lista de adyacencia: cada vertice tiene su lista de conexiones
    private Dictionary<string, List<Nodo>> lista;
    private bool dirigido;
    public string Nombre { get; private set; }

    public Grafo(string nombre, bool dirigido)
    {
        Nombre = nombre;
        this.dirigido = dirigido;
        lista = new Dictionary<string, List<Nodo>>();
    }

    // Agrega un vertice nuevo si no existe
    public void AgregarVertice(string v)
    {
        if (!lista.ContainsKey(v))
            lista[v] = new List<Nodo>();
    }

    // Agrega arista; si no es dirigido la agrega en ambas direcciones
    public void AgregarArista(string origen, string destino, int peso)
    {
        AgregarVertice(origen);
        AgregarVertice(destino);
        lista[origen].Add(new Nodo(destino, peso));
        if (!dirigido)
            lista[destino].Add(new Nodo(origen, peso));
    }

    // Muestra todos los vertices con sus conexiones
    public void MostrarLista()
    {
        Titulo($"Lista de Adyacencia  [{Nombre}]");
        foreach (var par in lista)
        {
            Console.Write($"  {par.Key,-30} -> ");
            if (par.Value.Count == 0)
                Console.WriteLine("(sin conexiones)");
            else
            {
                foreach (var n in par.Value)
                    Console.Write($"{n.Nombre} (w:{n.Peso})   ");
                Console.WriteLine();
            }
        }
    }

    // Muestra la matriz de adyacencia con 1 si hay conexion y 0 si no
    public void MostrarMatriz()
    {
        Titulo($"Matriz de Adyacencia  [{Nombre}]");
        var verts = new List<string>(lista.Keys);
        int n = verts.Count;

        // Encabezado de columnas
        Console.Write($"{"",25}");
        foreach (var v in verts)
            Console.Write($"{v,25}");
        Console.WriteLine();

        // Fila por cada vertice
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{verts[i],25}");
            for (int j = 0; j < n; j++)
            {
                bool hay = lista[verts[i]].Exists(x => x.Nombre == verts[j]);
                Console.Write($"{(hay ? 1 : 0),25}");
            }
            Console.WriteLine();
        }
    }

    // Busca y muestra todas las conexiones de un vertice especifico
    public void ConsultarVertice(string vertice)
    {
        if (!lista.ContainsKey(vertice))
        {
            Console.WriteLine($"  El vertice '{vertice}' no existe en este grafo.");
            return;
        }
        Titulo($"Conexiones de: {vertice}");
        if (lista[vertice].Count == 0)
            Console.WriteLine("  Sin conexiones.");
        else
            foreach (var n in lista[vertice])
                Console.WriteLine($"    -> {n.Nombre}  (peso: {n.Peso})");
    }

    // Muestra tipo, cantidad de vertices y aristas del grafo
    public void MostrarEstadisticas()
    {
        int totalAristas = 0;
        foreach (var v in lista)
            totalAristas += v.Value.Count;
        if (!dirigido) totalAristas /= 2;

        Titulo($"Estadisticas  [{Nombre}]");
        Console.WriteLine($"  Tipo     : {(dirigido ? "Dirigido" : "No dirigido")}");
        Console.WriteLine($"  Vertices : {lista.Count}");
        Console.WriteLine($"  Aristas  : {totalAristas}");
    }

    // Recorre el grafo nivel por nivel desde el vertice de inicio
    public void BFS(string inicio)
    {
        if (!lista.ContainsKey(inicio))
        {
            Console.WriteLine($"  El vertice '{inicio}' no existe.");
            return;
        }
        Titulo($"Recorrido BFS desde '{inicio}'  [{Nombre}]");

        var visitados = new HashSet<string>();
        var cola = new Queue<string>();
        cola.Enqueue(inicio);
        visitados.Add(inicio);

        Console.Write("  ");
        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            Console.Write($"{actual}  ->  ");
            foreach (var vecino in lista[actual])
            {
                if (!visitados.Contains(vecino.Nombre))
                {
                    visitados.Add(vecino.Nombre);
                    cola.Enqueue(vecino.Nombre);
                }
            }
        }
        Console.WriteLine();
    }

    public List<string> Vertices() => new List<string>(lista.Keys);

    // Imprime un titulo con linea separadora
    private void Titulo(string texto)
    {
        Console.WriteLine();
        Console.WriteLine($"  {texto}");
        Console.WriteLine("  " + new string('-', texto.Length + 2));
    }
}