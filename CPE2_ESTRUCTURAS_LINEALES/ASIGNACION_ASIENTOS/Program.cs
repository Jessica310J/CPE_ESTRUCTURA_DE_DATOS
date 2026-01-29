using System;

namespace GuiaPracticas02_EstructurasLineales
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("   SISTEMA DE ASIGNACIÓN DE ASIENTOS - PARQUE    ");
            Console.WriteLine("   Estructura: Cola (Queue) - Orden de Llegada   ");
            Console.WriteLine("=================================================\n");

            // Instancia del sistema de asignación
            AsignacionAsientos atraccion = new AsignacionAsientos();

            // 1. Simulación de llegada de personas (Llenado de la estructura)
            // Intentamos ingresar 32 personas para demostrar el límite de 30
            Console.WriteLine("--- Fase 1: Llegada de personas a la fila ---");
            for (int i = 1; i <= 32; i++)
            {
                atraccion.RecibirPersona($"Estudiante_{i}", i);
            }

            // 2. Reportería antes de asignar
            atraccion.MostrarEstadoCola();

            // Pausa para que el usuario vea el reporte
            Console.WriteLine("Presione ENTER para comenzar a subir a la atracción...");
            Console.ReadLine();

            // 3. Procesamiento (Vaciado de la estructura)
            atraccion.ProcesarAsignacion();
            
            // Pausa final
            Console.WriteLine("\nFin de la práctica. Presione una tecla para salir.");
            Console.ReadKey();
        }
    }
}