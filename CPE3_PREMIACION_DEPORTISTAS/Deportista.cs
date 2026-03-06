using System;

namespace GuiaPracticas03_Premiacion
{
    public class Deportista
    {
        public string Id         { get; set; }
        public string Nombre     { get; set; }
        public string Disciplina { get; set; }
        public double Puntaje    { get; set; }
        public string Medalla    { get; set; }

        public Deportista(string id, string nombre, string disciplina, double puntaje)
        {
            Id         = id;
            Nombre     = nombre;
            Disciplina = disciplina;
            Puntaje    = puntaje;
            Medalla    = "Sin medalla";
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre,-18} | {Disciplina,-12} | Puntaje: {Puntaje,5:F1} | {Medalla}";
        }
    }
}