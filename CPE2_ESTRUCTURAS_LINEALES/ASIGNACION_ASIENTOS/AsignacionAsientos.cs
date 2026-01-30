using System;
using System.Collections.Generic; // Librería para usar Queue (Cola)
using System.Diagnostics;       // Librería para medir tiempos de ejecución

namespace GuiaPracticas02_EstructurasLineales
{
    public class AsignacionAsientos
    {
        // Declaración de la Estructura de Datos Lineal: COLA (Queue)
        // Se escoge Queue porque el problema exige "Orden de llegada" (FIFO)
        private Queue<Persona> colaDeEspera;
        
        // Constante definida por el ejercicio: 30 asientos
        private const int TOTAL_ASIENTOS = 30;

        public AsignacionAsientos()
        {
            colaDeEspera = new Queue<Persona>();
        }

        // Método para encolar (Simula la llegada a la línea de espera)
        public void RecibirPersona(string nombre, int turno)
        {
            // Verificamos si la cola supera la capacidad de la atracción
            if (colaDeEspera.Count < TOTAL_ASIENTOS)
            {
                Persona nuevaPersona = new Persona(nombre, turno);
                colaDeEspera.Enqueue(nuevaPersona); // ENQUEUE: Agrega al final
                Console.WriteLine($"[INGRESO] {nuevaPersona.Nombre} tiene el ticket {nuevaPersona.Ticket}.");
            }
            else
            {
                Console.WriteLine($"[LLENO] Lo sentimos {nombre}, la atracción completó los {TOTAL_ASIENTOS} asientos.");
            }
        }

        // Actividad de Reportería: Visualizar elementos
        public void MostrarEstadoCola()
        {
            Console.WriteLine("\n--- REPORTE: ESTADO DE LA COLA DE ESPERA ---");
            Console.WriteLine($"Personas en espera: {colaDeEspera.Count} / {TOTAL_ASIENTOS}");
            
            foreach (var p in colaDeEspera)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("--------------------------------------------\n");
        }

        // Método principal: Asignar los asientos en orden (Procesar la Cola)
        public void ProcesarAsignacion()
        {
            Console.WriteLine(">>> INICIANDO ASIGNACIÓN DE ASIENTOS (TIKETS) <<<");
            
            Stopwatch tiempoEjecucion = new Stopwatch();
            tiempoEjecucion.Start(); // Inicio análisis de tiempo  

            int asientoNumero = 1;

            // Mientras existan personas en la cola, las asignamos a un asiento
            while (colaDeEspera.Count > 0)
            {
                // DEQUEUE: Extrae al primero que entró (Principio FIFO)
                Persona personaAtendida = colaDeEspera.Dequeue();
                
                Console.WriteLine($"Asignando Asiento #{asientoNumero} a: {personaAtendida.Nombre} ({personaAtendida.Ticket})");
                asientoNumero++;
            }

            tiempoEjecucion.Stop(); // Fin análisis de tiempo
            
            Console.WriteLine("\n>>> TODOS LOS ASIENTOS ASIGNADOS <<<");
            Console.WriteLine($"Tiempo total de ejecución del algoritmo: {tiempoEjecucion.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Análisis: La estructura Cola garantiza que el primer ticket generado fue el primero en subir.");
        }
    }
}