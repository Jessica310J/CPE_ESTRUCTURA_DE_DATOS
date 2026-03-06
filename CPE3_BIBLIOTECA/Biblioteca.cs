using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca
{
    // ========================================================================
    // CLASE: Biblioteca (Gestor/Controlador)
    // Centraliza la lógica de negocio. Administra el almacenamiento, las
    // búsquedas y las operaciones lógicas entre las colecciones de datos.
    // ========================================================================
    public class Biblioteca
    {
        // Implementación de Mapas (Diccionarios):
        // Se utiliza Dictionary<TKey, TValue> para asociar una clave única (IDLibro) con su valor correspondiente (el objeto Libro completo).
        // Esto permite búsquedas e inserciones directas
        private Dictionary<string, Libro> catalogo;

        // Implementación de Conjuntos (HashSet):
        // Se utiliza HashSet<string> para almacenar los identificadores únicos agrupados por categorías. 
        // Los conjuntos no permiten elementos duplicados y están optimizados para operaciones lógicas matemáticas.
        private HashSet<string> librosCiencia;
        private HashSet<string> librosNuevos;

        // Constructor que inicializa las colecciones en memoria.
        public Biblioteca()
        {
            catalogo = new Dictionary<string, Libro>();
            librosCiencia = new HashSet<string>();
            librosNuevos = new HashSet<string>();
        }

        // --- MÉTODOS DE GESTIÓN (CRUD) ---

        // Método para registrar un nuevo libro en el mapa y clasificarlo en conjuntos.
        public void AgregarLibro(Libro libro, bool esCiencia, bool esNuevo)
        {
            // El método ContainsKey valida si la clave ya existe de forma inmediata.
            if (!catalogo.ContainsKey(libro.IDLibro))
            {
                catalogo.Add(libro.IDLibro, libro); 
                
                // Si cumple la condición, se añade el ID al conjunto correspondiente.
                if (esCiencia) librosCiencia.Add(libro.IDLibro);
                if (esNuevo) librosNuevos.Add(libro.IDLibro);
                
                Console.WriteLine($"\n[Éxito] Libro '{libro.Titulo}' registrado correctamente.");
            }
            else
            {
                Console.WriteLine($"\n[Error] El ID {libro.IDLibro} ya se encuentra registrado.");
            }
        }

        // Método de búsqueda secuencial. 
        // Como el Diccionario está indexado por IDLibro, buscar por otra propiedad (Título) requiere iterar sobre todos los valores,
        public void ConsultarPorNombre(string nombreBusqueda)
        {
            Console.WriteLine($"\n--- RESULTADOS DE BÚSQUEDA: '{nombreBusqueda}' ---");
            bool encontrado = false;

            foreach (var libro in catalogo.Values)
            {
                // El parámetro StringComparison.OrdinalIgnoreCase permite que la búsqueda no sea sensible a mayúsculas o minúsculas.
                if (libro.Titulo.Contains(nombreBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"-> {libro}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron libros con ese nombre.");
            }
        }

        // Método para recorrer y mostrar todos los elementos almacenados en el mapa.
        public void VisualizarTodos()
        {
            Console.WriteLine("\n--- CATÁLOGO COMPLETO DE LIBROS ---");
            if (catalogo.Count == 0)
            {
                Console.WriteLine("La biblioteca no tiene registros actuales.");
                return;
            }

            foreach (var libro in catalogo.Values)
            {
                Console.WriteLine(libro);
            }
            Console.WriteLine($"Total de libros registrados: {catalogo.Count}");
        }

        // --- OPERACIONES LÓGICAS (TEORÍA DE CONJUNTOS) ---

        // Método que ejecuta las operaciones de Unión, Intersección y Diferencia
        // utilizando las funciones nativas optimizadas de la clase HashSet.
        public void GenerarReporteTeoriaConjuntos()
        {
            Console.WriteLine("\n=== REPORTERÍA: OPERACIONES DE CONJUNTOS ===");

            // UNIÓN: Combina los elementos de ambos conjuntos. UnionWith ignora los duplicados.
            HashSet<string> union = new HashSet<string>(librosCiencia);
            union.UnionWith(librosNuevos);
            Console.WriteLine("\n-> UNIÓN (Libros de Ciencia O Nuevos):");
            MostrarResultados(union);

            // INTERSECCIÓN: Mantiene exclusivamente los elementos que existen en ambos conjuntos.
            HashSet<string> interseccion = new HashSet<string>(librosCiencia);
            interseccion.IntersectWith(librosNuevos);
            Console.WriteLine("\n-> INTERSECCIÓN (Libros de Ciencia que TAMBIÉN son Nuevos):");
            MostrarResultados(interseccion);

            // DIFERENCIA: Resta del primer conjunto los elementos que coincidan con el segundo.
            HashSet<string> diferencia = new HashSet<string>(librosCiencia);
            diferencia.ExceptWith(librosNuevos);
            Console.WriteLine("\n-> DIFERENCIA (Libros de Ciencia que NO son Nuevos):");
            MostrarResultados(diferencia);
            
            Console.WriteLine("============================================");
        }

        // Método auxiliar para cruzar los datos. Recibe un conjunto de IDs y extrae 
        // el objeto completo desde el mapa principal (catalogo) para mostrar el título.
        private void MostrarResultados(HashSet<string> conjuntoClaves)
        {
            if (conjuntoClaves.Count == 0) Console.WriteLine("   (Ningún registro cumple la condición)");
            
            foreach (string clave in conjuntoClaves)
            {
                // TryGetValue recupera el objeto asociado a la clave de forma segura sin lanzar excepciones.
                if (catalogo.TryGetValue(clave, out Libro libro))
                {
                    Console.WriteLine($"   * {libro.Titulo}");
                }
            }
        }
    }
}