using System;

namespace GuiaPracticas02_EstructurasLineales // <--- IMPORTANTE: Mismo namespace
{
    public class Persona  // <--- Nombre de la clase
    {
        public string Nombre { get; set; }
        public string Ticket { get; set; }
        public DateTime HoraLlegada { get; set; }

        // ERROR COMÚN AQUÍ: Seguro tenías "public Visitante". 
        // Debe ser "public Persona":
        public Persona(string nombre, int numeroTurno) 
        {
            Nombre = nombre;
            Ticket = $"T-{numeroTurno:D3}"; 
            HoraLlegada = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Ticket} | {Nombre} | Hora: {HoraLlegada.ToLongTimeString()}";
        }
    }
}