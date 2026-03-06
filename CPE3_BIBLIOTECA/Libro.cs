using System;

namespace SistemaBiblioteca
{
    // ========================================================================
    // CLASE: Libro (Modelo de Datos)
    // Representa la entidad principal del sistema. Su responsabilidad es 
    // almacenar y proteger la información de un libro específico.
    // ========================================================================
    public class Libro
    {
        // Propiedades encapsuladas. El modificador 'private set' asegura que
        // los valores solo se puedan asignar al momento de crear el objeto,
        // protegiendo la integridad de los datos.
        public string IDLibro { get; private set; } 
        public string Titulo { get; private set; }
        public string Autor { get; private set; }

        // Constructor de la clase. Inicializa el objeto en memoria con los 
        // valores obligatorios proporcionados por el usuario.
        public Libro(string idLibro, string titulo, string autor)
        {
            IDLibro = idLibro;
            Titulo = titulo;
            Autor = autor;
        }

        // Sobrescritura del método ToString() nativo de C#. 
        // Permite devolver una cadena de texto formateada con los datos del libro
        // cuando se intente imprimir el objeto directamente en consola.
        public override string ToString()
        {
            return $"[ID: {IDLibro}] {Titulo} (Autor: {Autor})";
        }
    }
}