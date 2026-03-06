using System;
using System.Diagnostics; 

namespace SistemaBiblioteca
{
    // ========================================================================
    // CLASE PRINCIPAL: Inicializa la aplicación y gestiona la interacción
    // con el usuario a través de la consola.
    // ========================================================================
    class Program
    {
        static void Main()
        {
            // La clase Stopwatch se utiliza para realizar métricas de rendimiento
            // calculando el tiempo exacto de ejecución del sistema.
            Stopwatch reloj = new Stopwatch();
            reloj.Start();

            // Instanciación del gestor principal de la aplicación.
            Biblioteca miBiblioteca = new Biblioteca();
            
            // Inserción de registros iniciales para pruebas. 
            // Los IDLibro simulan secuencias alfanuméricas (ej. LIB001).
            miBiblioteca.AgregarLibro(new Libro("LIB001", "Estructura de Datos", "Joyanes"), true, false);
            miBiblioteca.AgregarLibro(new Libro("LIB002", "Sistemas Operativos", "Tanenbaum"), true, true);

            bool salir = false;

            // Estructura repetitiva para mantener la interfaz de usuario activa.
            while (!salir)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("          SISTEMA DE BIBLIOTECA         ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar nuevo libro");
                Console.WriteLine("2. Buscar libro por nombre");
                Console.WriteLine("3. Visualizar todos los libros");
                Console.WriteLine("4. Ver Reportería (Teoría de Conjuntos)");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                
                string opcion = Console.ReadLine();

                // Evaluador de casos según la opción ingresada por el usuario.
                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese ID del Libro (Ej. LIB003): ");
                        string idLibro = Console.ReadLine();
                        Console.Write("Ingrese Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese Autor: ");
                        string autor = Console.ReadLine();
                        
                        Console.Write("¿Es de la categoría Ciencia? (s/n): ");
                        bool esCiencia = Console.ReadLine().ToLower() == "s";
                        
                        Console.Write("¿Es un libro Nuevo? (s/n): ");
                        bool esNuevo = Console.ReadLine().ToLower() == "s";

                        // Creación y envío del nuevo objeto Libro al gestor.
                        miBiblioteca.AgregarLibro(new Libro(idLibro, titulo, autor), esCiencia, esNuevo);
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre (título) a buscar: ");
                        string busqueda = Console.ReadLine();
                        miBiblioteca.ConsultarPorNombre(busqueda);
                        break;

                    case "3":
                        miBiblioteca.VisualizarTodos();
                        break;

                    case "4":
                        miBiblioteca.GenerarReporteTeoriaConjuntos();
                        break;

                    case "5":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }

            // Finalización de la medición de rendimiento.
            reloj.Stop();
            
            // Visualización de las métricas obtenidas durante la sesión.
            Console.WriteLine($"\n[Análisis de Tiempo Final]");
            Console.WriteLine($"Tiempo total de la sesión (incluyendo espera de usuario): {reloj.ElapsedMilliseconds} ms.");
            Console.WriteLine("Programa finalizado correctamente.");
        }
    }
}