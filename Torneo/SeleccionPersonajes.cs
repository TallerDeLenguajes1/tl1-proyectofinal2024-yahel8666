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
            visuales.CentrarTexto("Seleccione el número del personaje que desea elegir (1 a " + personajes.Count + "):");
            int numeroSeleccionado;
            bool entradaValida;
            do
            {
                string entradaUsuario = Console.ReadLine();
                entradaValida = int.TryParse(entradaUsuario, out numeroSeleccionado) && numeroSeleccionado >= 1 && numeroSeleccionado <= personajes.Count;
                if (!entradaValida)
                {
                    visuales.CentrarTexto("Entrada inválida. Por favor, ingrese un número entre 1 y " + personajes.Count + ":");
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
            Console.Clear();
            visuales.CentrarTexto("Ahora vamos a elegir a tus enemigos...");
            Thread.Sleep(3000);
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                Personaje contrincante = personajes[random.Next(personajes.Count)];
                listadoDeEnemigos.Add(contrincante);
                personajes.Remove(contrincante);
            }
            visuales.CentrarTexto("Todo listo! Que la fuerza te acompañe");
            Thread.Sleep(2000);
            return listadoDeEnemigos;
        }

    }
}
