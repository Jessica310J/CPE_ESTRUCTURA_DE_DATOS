using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaTelefonicaIESS
{
    // Clase que gestiona la agenda telefónica del IESS
    public class AgendaTelefonica
    {
        // Lista (vector) para almacenar los contactos
        private List<Contacto> contactos;
        private int contadorId;

        // Constructor que inicializa la lista de contactos
        public AgendaTelefonica()
        {
            contactos = new List<Contacto>();
            contadorId = 1;
        }

        // Método para agregar un nuevo contacto
        public void AgregarContacto(string ide, string cedula, string nombre, string telefono, string departamento, string email)
        {
            Contacto nuevoContacto = new Contacto(contadorId, ide, cedula, nombre, telefono, departamento, email);
            contactos.Add(nuevoContacto);
            Console.WriteLine($"\n✓ Contacto agregado exitosamente con ID: {contadorId} - IDE: {ide}");
            contadorId++;
        }

        // Método para listar todos los contactos
        public void ListarContactos()
        {
            if (contactos.Count == 0)
            {
                Console.WriteLine("\n⚠ No hay contactos registrados en la agenda.");
                return;
            }

            Console.WriteLine("\n========== LISTA DE CONTACTOS IESS QUITO ==========");
            foreach (var contacto in contactos)
            {
                contacto.MostrarInformacion();
            }
            Console.WriteLine($"\nTotal de contactos: {contactos.Count}");
        }

        // Método para buscar contacto por nombre
        public void BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("\n⚠ Debe ingresar un nombre para buscar.");
                return;
            }

            var resultados = contactos.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine($"\n⚠ No se encontraron contactos con el nombre: {nombre}");
                return;
            }

            Console.WriteLine($"\n========== RESULTADOS DE BÚSQUEDA ==========");
            foreach (var contacto in resultados)
            {
                contacto.MostrarInformacion();
            }
        }

        // Método para buscar contactos por departamento
        public void BuscarPorDepartamento(string departamento)
        {
            if (string.IsNullOrEmpty(departamento))
            {
                Console.WriteLine("\n⚠ Debe ingresar un departamento para buscar.");
                return;
            }

            var resultados = contactos.Where(c => c.Departamento.ToLower().Contains(departamento.ToLower())).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine($"\n⚠ No se encontraron contactos en el departamento: {departamento}");
                return;
            }

            Console.WriteLine($"\n========== CONTACTOS DEL DEPARTAMENTO: {departamento.ToUpper()} ==========");
            foreach (var contacto in resultados)
            {
                contacto.MostrarInformacion();
            }
        }

        // Método para eliminar un contacto por ID
        public void EliminarContacto(int id)
        {
            var contacto = contactos.FirstOrDefault(c => c.Id == id);

            if (contacto == null)
            {
                Console.WriteLine($"\n⚠ No se encontró un contacto con ID: {id}");
                return;
            }

            contactos.Remove(contacto);
            Console.WriteLine($"\n✓ Contacto '{contacto.Nombre}' (IDE: {contacto.IDE}) eliminado exitosamente.");
        }

        // Método para obtener el total de contactos
        public int ObtenerTotalContactos()
        {
            return contactos.Count;
        }
    }
}