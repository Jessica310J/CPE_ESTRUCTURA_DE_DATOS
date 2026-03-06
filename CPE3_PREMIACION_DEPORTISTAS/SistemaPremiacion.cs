using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GuiaPracticas03_Premiacion
{
    public class SistemaPremiacion
    {
        // Dictionary: guarda cada deportista por su ID
        private Dictionary<string, Deportista> _deportistas = new Dictionary<string, Deportista>();

        // HashSet: guarda las disciplinas sin repetir
        private HashSet<string> _disciplinas = new HashSet<string>();

        // SortedDictionary: clasifica a los deportistas por puntaje dentro de cada disciplina
        private Dictionary<string, SortedDictionary<double, string>> _ranking
            = new Dictionary<string, SortedDictionary<double, string>>();

        // Registrar un deportista
        public void Registrar(string id, string nombre, string disciplina, double puntaje)
        {
            if (_deportistas.ContainsKey(id))
            {
                Console.WriteLine($"[ERROR] El ID {id} ya existe.");
                return;
            }

            _deportistas[id] = new Deportista(id, nombre, disciplina, puntaje);
            _disciplinas.Add(disciplina); // HashSet ignora si ya existe

            if (!_ranking.ContainsKey(disciplina))
                _ranking[disciplina] = new SortedDictionary<double, string>(
                    Comparer<double>.Create((a, b) => b.CompareTo(a)) // orden de mayor a menor
                );

            _ranking[disciplina][puntaje] = id;

            Console.WriteLine($"[OK] {nombre,-18} | {disciplina,-12} | {puntaje} pts");
        }

        // Mostrar las disciplinas registradas (HashSet)
        public void MostrarDisciplinas()
        {
            Console.WriteLine("\n--- DISCIPLINAS REGISTRADAS (HashSet) ---");
            foreach (string d in _disciplinas)
                Console.WriteLine($"   * {d}");
        }

        // Buscar un deportista por ID (Dictionary)
        public void Buscar(string id)
        {
            Console.WriteLine($"\n--- BUSCAR ID: {id} ---");
            if (_deportistas.TryGetValue(id, out Deportista dep))
                Console.WriteLine(dep.ToString());
            else
                Console.WriteLine($"No se encontro el ID: {id}");
        }

        // Asignar medallas por disciplina (SortedDictionary)
        public void AsignarMedallas()
        {
            Console.WriteLine("\n--- PREMIACION POR DISCIPLINA (SortedDictionary) ---");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] medallas = { "Medalla de ORO", "Medalla de PLATA", "Medalla de BRONCE" };

            foreach (string disciplina in _disciplinas)
            {
                Console.WriteLine($"\n  [ {disciplina.ToUpper()} ]");
                int pos = 1;
                foreach (var par in _ranking[disciplina])
                {
                    Deportista dep = _deportistas[par.Value];
                    if (pos <= 3)
                        dep.Medalla = medallas[pos - 1];
                    Console.WriteLine($"  {pos}. {dep}");
                    pos++;
                }
            }

            sw.Stop();
            Console.WriteLine($"\nTiempo de ejecucion: {sw.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine("La estructura SortedDictionary ordena automaticamente en O(log n).");
        }

        // Mostrar todos los deportistas registrados
        public void MostrarTodos()
        {
            Console.WriteLine("\n--- LISTA COMPLETA DE DEPORTISTAS ---");
            Console.WriteLine($"Total registrados: {_deportistas.Count}");
            foreach (var dep in _deportistas.Values)
                Console.WriteLine(dep.ToString());
        }
    }
}