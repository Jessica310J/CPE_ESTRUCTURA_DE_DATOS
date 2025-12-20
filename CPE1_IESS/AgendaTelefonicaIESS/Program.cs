using System;

namespace AgendaTelefonicaIESS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancia de la agenda telefónica
            AgendaTelefonica agenda = new AgendaTelefonica();
            
            // Cargar datos de ejemplo del IESS Quito
            CargarDatosEjemplo(agenda);

            bool salir = false;

            // Menú principal
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("*  DIRECTORIO INSTITUCIONAL - IESS QUITO              *");
                Console.WriteLine("*  Control y Gestión de Contactos Telefónicos         *");
                Console.WriteLine("********************************************************");
                Console.WriteLine("\n1. Listar todos los contactos");
                Console.WriteLine("2. Buscar contacto por nombre");
                Console.WriteLine("3. Buscar contactos por departamento");
                Console.WriteLine("4. Agregar nuevo contacto");
                Console.WriteLine("5. Eliminar contacto");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Listar todos los contactos
                        Console.Clear();
                        agenda.ListarContactos();
                        break;

                    case "2":
                        // Buscar por nombre
                        Console.Clear();
                        Console.Write("Ingrese el nombre a buscar: ");
                        string? nombreBuscar = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nombreBuscar))
                        {
                            agenda.BuscarPorNombre(nombreBuscar);
                        }
                        break;

                    case "3":
                        // Buscar por departamento
                        Console.Clear();
                        Console.Write("Ingrese el departamento a buscar: ");
                        string? departamentoBuscar = Console.ReadLine();
                        if (!string.IsNullOrEmpty(departamentoBuscar))
                        {
                            agenda.BuscarPorDepartamento(departamentoBuscar);
                        }
                        break;

                    case "4":
                        // Agregar nuevo contacto
                        Console.Clear();
                        Console.WriteLine("=== AGREGAR NUEVO CONTACTO ===\n");
                        
                        Console.Write("IDE (ejemplo: 0056): ");
                        string? ide = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Cédula (10 dígitos): ");
                        string? cedula = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Nombre completo: ");
                        string? nombre = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Teléfono: ");
                        string? telefono = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Departamento: ");
                        string? departamento = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Email: ");
                        string? email = Console.ReadLine() ?? string.Empty;
                        
                        agenda.AgregarContacto(ide, cedula, nombre, telefono, departamento, email);
                        break;

                    case "5":
                        // Eliminar contacto
                        Console.Clear();
                        Console.WriteLine("=== ELIMINAR CONTACTO ===\n");
                        Console.WriteLine("Contactos disponibles para eliminar:");
                        agenda.ListarContactos();
                        Console.Write("\nIngrese el ID del contacto a eliminar: ");
                        string? idInput = Console.ReadLine();
                        if (int.TryParse(idInput, out int idEliminar))
                        {
                            agenda.EliminarContacto(idEliminar);
                        }
                        else
                        {
                            Console.WriteLine("\n⚠ ID inválido.");
                        }
                        break;

                    case "6":
                        // Salir del programa
                        salir = true;
                        Console.Clear();
                        Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                                                    ║");
                        Console.WriteLine("║   GRACIAS POR VISITAR LA PÁGINA DEL IESS QUITO    ║");
                        Console.WriteLine("║              ¡REGRESE PRONTO!                      ║");
                        Console.WriteLine("║              ¡VELE TÚ!                             ║");
                        Console.WriteLine("║                                                    ║");
                        Console.WriteLine("╚════════════════════════════════════════════════════╝\n");
                        break;

                    default:
                        Console.WriteLine("\n⚠ Opción inválida. Intente nuevamente.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // Método para cargar datos de ejemplo del IESS Quito
        static void CargarDatosEjemplo(AgendaTelefonica agenda)
        {
            // Contactos precargados con IDE, cédulas de 10 dígitos y correos variados
            agenda.AgregarContacto("0056", "1756234890", "María Rodríguez", "02-398-7600", "Afiliación", "maria.rodriguez@gmail.com");
            agenda.AgregarContacto("0127", "1423567891", "Carlos Pérez", "02-398-7650", "Prestaciones", "carlos.perez@hotmail.com");
            agenda.AgregarContacto("0089", "0198765432", "Ana García", "02-398-7700", "Recaudación", "ana.garcia@live.com");
            agenda.AgregarContacto("0234", "1734568921", "Luis Morales", "02-398-7750", "Pensiones", "luis.morales@gmail.com");
            agenda.AgregarContacto("0145", "1445678932", "Carmen Vásquez", "02-398-7800", "Atención al Usuario", "carmen.vasquez@hotmail.com");
            
            Console.Clear();
        }
    }
}