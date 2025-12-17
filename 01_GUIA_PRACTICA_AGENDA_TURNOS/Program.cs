using System;

namespace _01_GUIA_PRACTICA_AGENDA_TURNOS
{
    /// <summary>
    /// Clase principal que contiene el menú de usuario y controla el flujo del programa
    /// Autores: Jessica Pesantez y Miguel Flores - Universidad Estatal Amazónica
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia de la agenda que gestiona todos los turnos
            AgendaClinica agenda = new AgendaClinica();
            int opcion;

            // Datos de prueba iniciales con los 4 pacientes
            CargarDatosPrueba(agenda);

            // Bucle principal del menú
            do
            {
                MostrarMenu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        RegistrarNuevoTurno(agenda);
                        break;
                    case 2:
                        agenda.ListarTodosTurnos();
                        break;
                    case 3:
                        BuscarTurno(agenda);
                        break;
                    case 4:
                        BuscarPorCedula(agenda);
                        break;
                    case 5:
                        FiltrarPorEspecialidad(agenda);
                        break;
                    case 6:
                        ActualizarEstadoTurno(agenda);
                        break;
                    case 7:
                        EliminarTurno(agenda);
                        break;
                    case 8:
                        agenda.MostrarEstadisticas();
                        break;
                    case 0:
                        Console.WriteLine("\n¡Gracias por usar el sistema! Hasta pronto.");
                        break;
                    default:
                        Console.WriteLine("\n✗ Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        // Método que muestra el menú principal
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE GESTIÓN DE TURNOS - CLÍNICA SALUD     ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
            Console.WriteLine("\n  [1] Registrar nuevo turno");
            Console.WriteLine("  [2] Listar todos los turnos");
            Console.WriteLine("  [3] Buscar turno por número");
            Console.WriteLine("  [4] Buscar turnos por cédula del paciente");
            Console.WriteLine("  [5] Filtrar turnos por especialidad");
            Console.WriteLine("  [6] Actualizar estado de turno");
            Console.WriteLine("  [7] Cancelar turno");
            Console.WriteLine("  [8] Ver estadísticas");
            Console.WriteLine("  [0] Salir del sistema");
            Console.WriteLine("\n═════════════════════════════════════════════════════");
            Console.Write("  Seleccione una opción: ");
        }

        // Método para leer y validar la opción del menú
        static int LeerOpcion()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }

        // Método para registrar un nuevo turno
        static void RegistrarNuevoTurno(AgendaClinica agenda)
        {
            Console.WriteLine("\n--- REGISTRAR NUEVO TURNO ---");

            Console.Write("Cédula del paciente: ");
            string cedula = Console.ReadLine();

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            // Crear el objeto Paciente con todos los datos
            Paciente paciente = new Paciente(cedula, nombre, telefono, email, direccion, edad, DateTime.Now);

            Console.Write("Especialidad (Medicina General/Pediatría/Cardiología/Dermatología): ");
            string especialidad = Console.ReadLine();

            Console.Write("Nombre del médico: ");
            string medico = Console.ReadLine();

            Console.Write("Fecha del turno (dd/MM/yyyy): ");
            string fechaStr = Console.ReadLine();

            Console.Write("Hora del turno (HH:mm): ");
            string horaStr = Console.ReadLine();

            // Combinar fecha y hora
            DateTime fechaHora = DateTime.Parse($"{fechaStr} {horaStr}");

            // Agregar el turno a la agenda
            agenda.AgregarTurno(paciente, fechaHora, especialidad, medico);
        }

        // Método para buscar un turno por número
        static void BuscarTurno(AgendaClinica agenda)
        {
            Console.Write("\nIngrese el número de turno: ");
            int numero = int.Parse(Console.ReadLine());
            agenda.BuscarTurnoPorNumero(numero);
        }

        // Método para buscar turnos por cédula
        static void BuscarPorCedula(AgendaClinica agenda)
        {
            Console.Write("\nIngrese la cédula del paciente: ");
            string cedula = Console.ReadLine();
            agenda.BuscarTurnosPorCedula(cedula);
        }

        // Método para filtrar turnos por especialidad
        static void FiltrarPorEspecialidad(AgendaClinica agenda)
        {
            Console.Write("\nIngrese la especialidad: ");
            string especialidad = Console.ReadLine();
            agenda.ListarTurnosPorEspecialidad(especialidad);
        }

        // Método para actualizar el estado de un turno
        static void ActualizarEstadoTurno(AgendaClinica agenda)
        {
            Console.Write("\nIngrese el número de turno: ");
            int numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Estados disponibles: Pendiente, Atendido, Cancelado");
            Console.Write("Nuevo estado: ");
            string estado = Console.ReadLine();

            agenda.CambiarEstadoTurno(numero, estado);
        }

        // Método para cancelar/eliminar un turno
        static void EliminarTurno(AgendaClinica agenda)
        {
            Console.Write("\nIngrese el número de turno a cancelar: ");
            int numero = int.Parse(Console.ReadLine());
            agenda.CancelarTurno(numero);
        }

        // Método para cargar datos de prueba al iniciar
        static void CargarDatosPrueba(AgendaClinica agenda)
        {
            // Datos reales de pacientes - Universidad Estatal Amazónica
            // Datos proporcionados por: Miguel Flores y Jessica Pesantez
            
            Paciente p1 = new Paciente(
                "1725896314", 
                "Miguel Flores", 
                "0991234567", 
                "flores_156_vago@gmail.com",
                "Av. America y Luis Arroyo",
                25,
                new DateTime(2025, 12, 10)
            );

            Paciente p2 = new Paciente(
                "1704523698", 
                "Jessica Pesantez", 
                "0991234588", 
                "Jess_15_15@gmail.com",
                "Av. Juan de Salinas",
                28,
                new DateTime(2025, 12, 11)
            );

            Paciente p3 = new Paciente(
                "1712345678", 
                "Victoria Arias", 
                "0998964567", 
                "viky_arias_1995@gmail.com",
                "Av. Kiruba y Zambrano",
                30,
                new DateTime(2025, 12, 12)
            );

            Paciente p4 = new Paciente(
                "1798564580", 
                "Carlos Cuadros", 
                "0989564580", 
                "cuadros_rectangulo156@gmail.com",
                "Av. Canelos y Plaza",
                32,
                new DateTime(2025, 12, 15)
            );

            // Asignar turnos médicos a los pacientes
            agenda.AgregarTurno(p1, new DateTime(2025, 12, 20, 10, 0, 0), "Medicina General", "Ana Torres");
            agenda.AgregarTurno(p2, new DateTime(2025, 12, 21, 14, 30, 0), "Pediatría", "Luis Morales");
            agenda.AgregarTurno(p3, new DateTime(2025, 12, 22, 9, 0, 0), "Cardiología", "Carmen Vega");
            agenda.AgregarTurno(p4, new DateTime(2025, 12, 23, 15, 30, 0), "Dermatología", "Roberto Sánchez");
        }
    }
}