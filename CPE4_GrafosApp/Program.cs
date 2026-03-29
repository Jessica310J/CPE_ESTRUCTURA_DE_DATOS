using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Encabezado();

        // Carga los dos grafos desde los archivos .txt y mide el tiempo
        var sw = Stopwatch.StartNew();
        Grafo g1 = LectorGrafo.LeerDesdeArchivo("grafo1.txt", "Materias Universitarias");
        Grafo g2 = LectorGrafo.LeerDesdeArchivo("grafo2.txt", "Red de Amigos del Aula");
        sw.Stop();

        Console.WriteLine($"  Grafos cargados correctamente  [{sw.ElapsedMilliseconds} ms]");

        bool salir = false;
        while (!salir)
        {
            Menu();
            Console.Write("  Opcion: ");
            string opcion = Console.ReadLine()?.Trim();

            // Opciones 1-5 requieren seleccionar un grafo primero
            Grafo grafo = null;
            if (opcion != "0" && opcion != "6")
                grafo = SeleccionarGrafo(g1, g2);

            var timer = Stopwatch.StartNew();

            switch (opcion)
            {
                case "1":
                    grafo.MostrarLista();
                    break;

                case "2":
                    grafo.MostrarMatriz();
                    break;

                case "3":
                    Console.WriteLine($"  Vertices disponibles: {string.Join(", ", grafo.Vertices())}");
                    Console.Write("  Vertice a consultar: ");
                    grafo.ConsultarVertice(Console.ReadLine()?.Trim());
                    break;

                case "4":
                    grafo.MostrarEstadisticas();
                    break;

                case "5":
                    Console.WriteLine($"  Vertices disponibles: {string.Join(", ", grafo.Vertices())}");
                    Console.Write("  Vertice de inicio BFS: ");
                    grafo.BFS(Console.ReadLine()?.Trim());
                    break;

                case "6":
                    // Muestra lista, matriz y estadisticas de ambos grafos
                    g1.MostrarLista();
                    g1.MostrarMatriz();
                    g1.MostrarEstadisticas();
                    Console.WriteLine();
                    g2.MostrarLista();
                    g2.MostrarMatriz();
                    g2.MostrarEstadisticas();
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("\n  Hasta luego.\n");
                    break;

                default:
                    Console.WriteLine("  Opcion no valida, intente de nuevo.");
                    break;
            }

            timer.Stop();
            if (opcion != "0")
                Console.WriteLine($"\n  Tiempo de operacion: {timer.ElapsedTicks} ticks  ({timer.ElapsedMilliseconds} ms)");
        }
    }

    // Pide al usuario que seleccione con cual grafo trabajar
    static Grafo SeleccionarGrafo(Grafo g1, Grafo g2)
    {
        Console.WriteLine();
        Console.WriteLine("  1  Materias Universitarias");
        Console.WriteLine("  2  Red de Amigos del Aula");
        Console.Write("  Seleccione grafo: ");
        return Console.ReadLine()?.Trim() == "2" ? g2 : g1;
    }

    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("  ----------------------------------------");
        Console.WriteLine("  MENU PRINCIPAL");
        Console.WriteLine("  ----------------------------------------");
        Console.WriteLine("  1   Lista de adyacencia");
        Console.WriteLine("  2   Matriz de adyacencia");
        Console.WriteLine("  3   Consultar vertice");
        Console.WriteLine("  4   Estadisticas del grafo");
        Console.WriteLine("  5   Recorrido BFS");
        Console.WriteLine("  6   Mostrar ambos grafos completos");
        Console.WriteLine("  0   Salir");
        Console.WriteLine("  ----------------------------------------");
    }

    static void Encabezado()
    {
        Console.WriteLine();
        Console.WriteLine("  ========================================");
        Console.WriteLine("  ESTRUCTURA DE DATOS  --  UEA 2025-2026");
        Console.WriteLine("  Ing. Tecnologias de la Informacion");
        Console.WriteLine("  ----------------------------------------");
        Console.WriteLine("  Integrantes:");
        Console.WriteLine("    - Jessica Pesantez");
        Console.WriteLine("    - Miguel Flores");
        Console.WriteLine("  ----------------------------------------");
        Console.WriteLine("  Practica #04  |  Grafos");
        Console.WriteLine("  ========================================");
        Console.WriteLine();
    }
}