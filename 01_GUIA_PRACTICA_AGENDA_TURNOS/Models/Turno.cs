using System;

namespace _01_GUIA_PRACTICA_AGENDA_TURNOS
{
    /// <summary>
    /// Clase que representa un turno médico asignado a un paciente
    /// Autores: Jessica Pesantez y Miguel Flores - Universidad Estatal Amazónica
    /// </summary>
    public class Turno
    {
        // Atributos privados del turno
        private int numeroTurno;
        private Paciente paciente;
        private DateTime fechaHora;
        private string especialidad;
        private string medico;
        private string estado; // Pendiente, Atendido, Cancelado

        // Propiedades públicas
        public int NumeroTurno
        {
            get { return numeroTurno; }
            set { numeroTurno = value; }
        }

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        // Constructor con parámetros
        public Turno(int numeroTurno, Paciente paciente, DateTime fechaHora, string especialidad, string medico)
        {
            this.numeroTurno = numeroTurno;
            this.paciente = paciente;
            this.fechaHora = fechaHora;
            this.especialidad = especialidad;
            this.medico = medico;
            this.estado = "Pendiente";
        }

        // Método para mostrar información del turno
        public void MostrarTurno()
        {
            Console.WriteLine($"\n╔══════════════════════════════════════════╗");
            Console.WriteLine($"║          TURNO #{numeroTurno}                     ");
            Console.WriteLine($"╚══════════════════════════════════════════╝");
            Console.WriteLine($" Fecha y Hora: {fechaHora:dd/MM/yyyy HH:mm}");
            Console.WriteLine($" Especialidad: {especialidad}");
            Console.WriteLine($" Médico: Dr(a). {medico}");
            Console.WriteLine($" Estado: {estado}");
            Console.WriteLine($"\n--- INFORMACIÓN DEL PACIENTE ---");
            paciente.MostrarInformacionCompleta();
            Console.WriteLine("==========================================");
        }
    }
}