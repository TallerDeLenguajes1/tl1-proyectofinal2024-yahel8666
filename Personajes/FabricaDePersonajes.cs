using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiProyecto;
namespace miProyecto;


public class fabricaPersonajes()
{
    private static int maxRetries = 5;
    private static int initialDelay = 1000;
    private static Random random = new Random();
    public async Task<Personaje> CrearPersonajeAleatorio()
    {
        // Llamada a una API para obtener un usuario aleatorio
        UsuarioAleatorio nuevoUsuario = await ObtenerUsuarioAleatorioConRetries();
        string nombre = nuevoUsuario.first_name;

        TiposPersonajes tipos = new TiposPersonajes();
        string tipo = tipos.obtenerTipoAleatorio();

        DateTime fechaNac = ObtenerFechaAleatoria();
        int edad = CalcularEdad(fechaNac);

        // Crea un objeto DatosPersonaje con la información obtenida. 
        DatosPersonaje datos = new DatosPersonaje(nombre, tipo, fechaNac, edad);

        // Generar valores aleatorios para las características del personaje
        int velocidad = random.Next(1, 11);
        int destreza = random.Next(1, 6);
        int fuerza = random.Next(1, 11);
        int armadura = random.Next(1, 11);
        int nivel = random.Next(1, 11);
        int salud = 100;

        CaracteristicasPersonaje caracteristicas = new CaracteristicasPersonaje(velocidad, armadura, fuerza, nivel, salud, destreza);

        Personaje nuevoPersonaje = new Personaje(datos, caracteristicas);
        return nuevoPersonaje;
    }

    private static async Task<UsuarioAleatorio> ObtenerUsuarioAleatorioConRetries()
    {
        int delay = initialDelay;

        for (int retry = 0; retry < maxRetries; retry++)
        {
            try
            {
                return await MiApi.GetGeneraUsuario();
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.TooManyRequests)
            {
                if (retry == maxRetries - 1)
                    throw;

                await Task.Delay(delay);
                delay *= 2; // Retraso exponencial
            }
        }

        throw new Exception("No se pudo obtener un usuario aleatorio después de varios intentos.");
    }



    private class TiposPersonajes
    {
        List<string> ListaDeTipos = new List<string> {
        "Mago", "Elfo", "Enano", "Humano", "Raconeano", "Demonio", "Angel"
        };

        public string obtenerTipoAleatorio()
        {
            int i = random.Next(ListaDeTipos.Count);
            return ListaDeTipos[i];
        }
    }
    private static DateTime ObtenerFechaAleatoria()
    {
        //a partir de esta fecha voy a tener en cuenta: 
        DateTime start = new DateTime(1700, 1, 1);

        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }
    private static int CalcularEdad(DateTime fechaNac)
    {
        int edad = DateTime.Today.Year - fechaNac.Year;
        return edad;
    }
}

