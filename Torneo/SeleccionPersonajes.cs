namespace miProyecto
{
    
    public class SeleccionPersonaje
    {
        Visuales visuales = new Visuales();
        public Personaje elegirMiPersonaje(List<Personaje> personajes)
        {
            if (personajes == null || personajes.Count == 0)
            {
                visuales.CentrarTexto("No hay personajes para seleccionar.");
                return null;
            }

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            visuales.CentrarTexto("Ingrese el número del personaje que desea elegir (1 a " + personajes.Count + "):");
            visuales.MostrarAColor("-----------------------", ConsoleColor.DarkCyan);
            int numeroSeleccionado;
            bool entradaValida;
            do
            {
                string entradaUsuario = Console.ReadLine();
                entradaValida = int.TryParse(entradaUsuario, out numeroSeleccionado) && numeroSeleccionado >= 1 && numeroSeleccionado <= personajes.Count;
                if (!entradaValida)
                {
                    visuales.MostrarAColor("Entrada inválida. Por favor, ingrese un número entre 1 y " + personajes.Count + ":", ConsoleColor.DarkRed);
                }
            } while (!entradaValida);
            Personaje personajeSeleccionado = personajes[numeroSeleccionado - 1];
            personajes.Remove(personajeSeleccionado);
            return personajeSeleccionado;
        }

        public List<Personaje> ObtenerEnemigos(List<Personaje> personajes)
        {
            List<Personaje> listadoDeEnemigos = new List<Personaje>();

            if (personajes == null || personajes.Count == 0)
            {
                visuales.CentrarTexto("No hay personajes para seleccionar.");
                return null;
            }
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                Personaje contrincante = personajes[random.Next(personajes.Count)];
                listadoDeEnemigos.Add(contrincante);
                personajes.Remove(contrincante);
            }
            return listadoDeEnemigos;
        }
    }
}
