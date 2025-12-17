using System;

namespace _01_GUIA_PRACTICA_AGENDA_TURNOS
{
    /// <summary>
    /// Clase que representa un paciente con sus datos básicos
    /// Autor: [Jessica Pesantez y Miguel Flores] - Universidad Estatal Amazónica
    /// </summary>
    public class Paciente
    {
        // Atributos privados del paciente
        private string cedula;
        private string nombre;
        private string telefono;
        private string email;
        private string direccion;
        private int edad;
        private DateTime fechaRegistro;

        // Propiedades públicas con validación
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        // Constructor vacío
        public Paciente()
        {
            this.fechaRegistro = DateTime.Now;
        }

        // Constructor completo con todos los parámetros
        public Paciente(string cedula, string nombre, string telefono, string email, 
                       string direccion, int edad, DateTime fechaRegistro)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.telefono = telefono;
            this.email = email;
            this.direccion = direccion;
            this.edad = edad;
            this.fechaRegistro = fechaRegistro;
        }

        // Método para mostrar información completa
        public void MostrarInformacionCompleta()
        {
            Console.WriteLine($"  Cédula: {cedula}");
            Console.WriteLine($"  Nombre: {nombre}");
            Console.WriteLine($"  Teléfono: {telefono}");
            Console.WriteLine($"  Email: {email}");
            Console.WriteLine($"  Dirección: {direccion}");
            Console.WriteLine($"  Edad: {edad} años");
            Console.WriteLine($"  Fecha de Registro: {fechaRegistro:dd/MM/yyyy}");
        }
    }
}