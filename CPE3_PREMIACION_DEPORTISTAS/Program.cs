using System;

namespace GuiaPracticas03_Premiacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("  SISTEMA DE PREMIACION DE DEPORTISTAS");
            Console.WriteLine("  Universidad Estatal Amazonica - UEA");
            Console.WriteLine("============================================\n");

            SistemaPremiacion sistema = new SistemaPremiacion();

            // FASE 1: Registro de deportistas con nombres reales
            Console.WriteLine("--- FASE 1: Registro de deportistas ---");

            // Natacion
            sistema.Registrar("D001", "Leandro Alava",    "Natacion",  88.5);
            sistema.Registrar("D002", "Cristian Alban",   "Natacion",  92.0);
            sistema.Registrar("D003", "Carlos Asencio",   "Natacion",  85.0);
            sistema.Registrar("D004", "Fredy Bastidas",   "Natacion",  90.5);
            sistema.Registrar("D005", "Edgar Bravo",      "Natacion",  78.0);

            // Atletismo
            sistema.Registrar("D006", "Johao Caicedo",    "Atletismo", 94.0);
            sistema.Registrar("D007", "Victor Carreno",   "Atletismo", 87.5);
            sistema.Registrar("D008", "Cinthia Carrion",  "Atletismo", 91.0);
            sistema.Registrar("D009", "Carlos Castillo",  "Atletismo", 83.5);
            sistema.Registrar("D010", "Steven Castro",    "Atletismo", 96.5);

            // Gimnasia
            sistema.Registrar("D011", "Sheyla Cedeno",    "Gimnasia",  89.0);
            sistema.Registrar("D012", "Cristhian Chacha", "Gimnasia",  93.5);
            sistema.Registrar("D013", "Marcos Delgado",   "Gimnasia",  80.0);
            sistema.Registrar("D014", "Bryan Escobar",    "Gimnasia",  95.0);
            sistema.Registrar("D015", "Henrry Espinoza",  "Gimnasia",  77.5);

            // Ciclismo
            sistema.Registrar("D016", "Carlos Figueroa",  "Ciclismo",  86.0);
            sistema.Registrar("D017", "Miguel Flores",    "Ciclismo",  91.5);
            sistema.Registrar("D018", "Kevin Galan",      "Ciclismo",  79.0);
            sistema.Registrar("D019", "Johanna Gamboa",   "Ciclismo",  97.0);
            sistema.Registrar("D020", "Victor Garofalo",  "Ciclismo",  84.5);

            // Intento de ID repetido (demuestra validacion del Dictionary)
            sistema.Registrar("D001", "Intruso Test", "Natacion", 99.0);

            // FASE 2: Ver disciplinas unicas (HashSet)
            sistema.MostrarDisciplinas();

            // FASE 3: Buscar deportista por ID (Dictionary O(1))
            sistema.Buscar("D010");
            sistema.Buscar("D999");

            // FASE 4: Ver todos los deportistas
            sistema.MostrarTodos();

            // FASE 5: Premiar por disciplina (SortedDictionary)
            sistema.AsignarMedallas();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}