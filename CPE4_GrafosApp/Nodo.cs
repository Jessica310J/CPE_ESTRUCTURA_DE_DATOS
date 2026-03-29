// Representa una conexion hacia otro vertice del grafo
class Nodo
{
    public string Nombre { get; set; }
    public int Peso { get; set; }

    public Nodo(string nombre, int peso)
    {
        Nombre = nombre;
        Peso = peso;
    }
}