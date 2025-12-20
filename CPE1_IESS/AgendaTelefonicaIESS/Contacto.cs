using System;

namespace AgendaTelefonicaIESS
{
    // Clase que representa un contacto del IESS
    public class Contacto
    {
        // Propiedades del contacto
        public int Id { get; set; }
        public string IDE { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Constructor vacío
        public Contacto()
        {
        }

        // Constructor con parámetros
        public Contacto(int id, string ide, string cedula, string nombre, string telefono, string departamento, string email)
        {
            Id = id;
            IDE = ide ?? string.Empty;
            Cedula = cedula ?? string.Empty;
            Nombre = nombre ?? string.Empty;
            Telefono = telefono ?? string.Empty;
            Departamento = departamento ?? string.Empty;
            Email = email ?? string.Empty;
        }

        // Método para mostrar la información del contacto
        public void MostrarInformacion()
        {
            Console.WriteLine($"\n--- Contacto #{Id} ---");
            Console.WriteLine($"IDE: {IDE}");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}