using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_GUIA_PRACTICA_AGENDA_TURNOS
{
    /// <summary>
    /// Clase que gestiona todos los turnos de la clínica
    /// Utiliza una Lista (estructura de datos dinámica) para almacenar los turnos
    /// Autores: Jessica Pesantez y Miguel Flores - Universidad Estatal Amazónica
    /// </summary>
    public class AgendaClinica
    {
        // Lista que almacena todos los turnos - Estructura de datos dinámica
        private List<Turno> turnos;
        private int contadorTurnos;

        // Constructor
        public AgendaClinica()
        {
            turnos = new List<Turno>();
            contadorTurnos = 1;
        }

        // Método para agregar un nuevo turno
        public void AgregarTurno(Paciente paciente, DateTime fechaHora, string especialidad, string medico)
        {
            Turno nuevoTurno = new Turno(contadorTurnos, paciente, fechaHora, especialidad, medico);
            turnos.Add(nuevoTurno);
            Console.WriteLine($"\n✓ Turno #{contadorTurnos} registrado exitosamente!");
            contadorTurnos++;
        }

        // Método para listar todos los turnos
        public void ListarTodosTurnos()
        {
            if (turnos.Count == 0)
            {
                Console.WriteLine("\n⚠ No hay turnos registrados.");
                return;
            }

            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║       LISTA DE TODOS LOS TURNOS           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");

            foreach (Turno turno in turnos)
            {
                turno.MostrarTurno();
            }
            Console.WriteLine($"\nTotal de turnos: {turnos.Count}");
        }

        // Método para buscar turno por número
        public void BuscarTurnoPorNumero(int numeroTurno)
        {
            // Búsqueda secuencial en la lista
            Turno turnoEncontrado = turnos.Find(t => t.NumeroTurno == numeroTurno);

            if (turnoEncontrado != null)
            {
                Console.WriteLine("\n✓ Turno encontrado:");
                turnoEncontrado.MostrarTurno();
            }
            else
            {
                Console.WriteLine($"\n✗ No se encontró el turno #{numeroTurno}");
            }
        }

        // Método para buscar turnos por cédula del paciente
        public void BuscarTurnosPorCedula(string cedula)
        {
            // Filtrado de turnos usando LINQ
            List<Turno> turnosEncontrados = turnos.Where(t => t.Paciente.Cedula == cedula).ToList();

            if (turnosEncontrados.Count > 0)
            {
                Console.WriteLine($"\n✓ Se encontraron {turnosEncontrados.Count} turno(s) para la cédula {cedula}:");
                foreach (Turno turno in turnosEncontrados)
                {
                    turno.MostrarTurno();
                }
            }
            else
            {
                Console.WriteLine($"\n✗ No se encontraron turnos para la cédula {cedula}");
            }
        }

        // Método para listar turnos por especialidad
        public void ListarTurnosPorEspecialidad(string especialidad)
        {
            List<Turno> turnosFiltrados = turnos.Where(t => 
                t.Especialidad.ToLower() == especialidad.ToLower()).ToList();

            if (turnosFiltrados.Count > 0)
            {
                Console.WriteLine($"\n--- Turnos de {especialidad} ---");
                foreach (Turno turno in turnosFiltrados)
                {
                    turno.MostrarTurno();
                }
            }
            else
            {
                Console.WriteLine($"\n✗ No hay turnos para {especialidad}");
            }
        }

        // Método para cambiar estado de un turno
        public void CambiarEstadoTurno(int numeroTurno, string nuevoEstado)
        {
            Turno turno = turnos.Find(t => t.NumeroTurno == numeroTurno);

            if (turno != null)
            {
                turno.Estado = nuevoEstado;
                Console.WriteLine($"\n✓ Estado del turno #{numeroTurno} actualizado a: {nuevoEstado}");
            }
            else
            {
                Console.WriteLine($"\n✗ No se encontró el turno #{numeroTurno}");
            }
        }

        // Método para cancelar un turno (eliminar)
        public void CancelarTurno(int numeroTurno)
        {
            Turno turno = turnos.Find(t => t.NumeroTurno == numeroTurno);

            if (turno != null)
            {
                turnos.Remove(turno);
                Console.WriteLine($"\n✓ Turno #{numeroTurno} cancelado y eliminado");
            }
            else
            {
                Console.WriteLine($"\n✗ No se encontró el turno #{numeroTurno}");
            }
        }

        // Método para obtener estadísticas
        public void MostrarEstadisticas()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║           ESTADÍSTICAS DE TURNOS          ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine($"Total de turnos: {turnos.Count}");
            Console.WriteLine($"Turnos pendientes: {turnos.Count(t => t.Estado == "Pendiente")}");
            Console.WriteLine($"Turnos atendidos: {turnos.Count(t => t.Estado == "Atendido")}");
            Console.WriteLine($"Turnos cancelados: {turnos.Count(t => t.Estado == "Cancelado")}");
        }
    }
}