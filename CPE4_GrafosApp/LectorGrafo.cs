using System.IO;

class LectorGrafo
{
    // Lee el archivo .txt linea por linea y construye el grafo
    public static Grafo LeerDesdeArchivo(string ruta, string nombre)
    {
        bool dirigido = false;
        string[] lineas = File.ReadAllLines(ruta);

        // Detecta si el grafo es dirigido leyendo los comentarios del archivo
        foreach (var linea in lineas)
            if (linea.Contains("DIRIGIDO: SI"))
                dirigido = true;

        var grafo = new Grafo(nombre, dirigido);

        foreach (var linea in lineas)
        {
            // Ignora lineas de comentario y lineas vacias
            if (linea.StartsWith("#") || string.IsNullOrWhiteSpace(linea))
                continue;

            var partes = linea.Split(',');
            if (partes.Length >= 3)
            {
                string origen  = partes[0].Trim();
                string destino = partes[1].Trim();
                int peso = int.TryParse(partes[2].Trim(), out int p) ? p : 1;
                grafo.AgregarArista(origen, destino, peso);
            }
        }
        return grafo;
    }
}