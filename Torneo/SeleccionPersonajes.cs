using System;
using System.Collections.Generic;

namespace miProyecto
{
    public class SeleccionPersonaje
    {
        public Personaje elegirMiPersonaje(List<Personaje> personajes)
        {
            if (personajes == null || personajes.Count == 0)
            {
                Visuales.CentrarTexto("No hay personajes para seleccionar.");
                return null;
            }

            Console.Clear();
            Visuales.CentrarTexto("Seleccione el número del personaje que desea elegir (1 a " + personajes.Count + "):");
            int numeroSeleccionado;
            bool entradaValida;
            do
            {
                string entradaUsuario = Console.ReadLine();
                entradaValida = int.TryParse(entradaUsuario, out numeroSeleccionado) && numeroSeleccionado >= 1 && numeroSeleccionado <= personajes.Count;

                if (!entradaValida)
                {
                    Visuales.CentrarTexto("Entrada inválida. Por favor, ingrese un número entre 1 y " + personajes.Count + ":");
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
                Visuales.CentrarTexto("No hay personajes para seleccionar.");
                return null;
            }
            Random random = new Random();
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (personajes.Count == 0)
                    break;

                Personaje contrincante = personajes[random.Next(personajes.Count)];
                listadoDeEnemigos.Add(contrincante);
                personajes.Remove(contrincante);
            }
            return listadoDeEnemigos;
        }
    }
}
