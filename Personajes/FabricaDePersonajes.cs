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
        //llamo a la api con espera  
        UsuarioAleatorio usuarioApi = await ObtenerUsuarioAleatorioConRetries();

        //control por si falla la api
        string nombre;
        if (usuarioApi== null)
        {
            nombre = ObtenerNombreAleatorio();
        }
        else
        {
            nombre = usuarioApi.first_name;
        }

        TiposPersonajes tipos = new TiposPersonajes();
        string tipo = tipos.obtenerTipoAleatorio();

        DateTime fechaNac = ObtenerFechaAleatoria();
        int edad = CalcularEdad(fechaNac);

        DatosPersonaje datos = new DatosPersonaje(nombre, tipo, fechaNac, edad);

        //caracteristicas segun tipo: 
        int velocidad, destreza, fuerza, armadura, nivel, salud;
        switch (tipo)
        {
            case "Mago":
                velocidad = random.Next(3, 8);
                destreza = random.Next(4, 7);
                fuerza = random.Next(1, 5);
                armadura = random.Next(2, 6);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Elfo":
                velocidad = random.Next(5, 10);
                destreza = random.Next(4, 8);
                fuerza = random.Next(2, 6);
                armadura = random.Next(3, 7);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Enano":
                velocidad = random.Next(1,11);
                destreza = random.Next(3, 7);
                fuerza = random.Next(5, 10);
                armadura = random.Next(4, 8);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Humano":
                velocidad = random.Next(4, 8);
                destreza = random.Next(4, 8);
                fuerza = random.Next(4, 8);
                armadura = random.Next(4, 8);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Raconeano":
                velocidad = random.Next(6, 10);
                destreza = random.Next(5, 9);
                fuerza = random.Next(3, 7);
                armadura = random.Next(2, 6);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Demonio":
                velocidad = random.Next(3, 8);
                destreza = random.Next(3, 7);
                fuerza = random.Next(6, 10);
                armadura = random.Next(4, 8);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            case "Angel":
                velocidad = random.Next(5, 9);
                destreza = random.Next(5, 9);
                fuerza = random.Next(4, 8);
                armadura = random.Next(3, 7);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
            default:
                velocidad = random.Next(1, 11);
                destreza = random.Next(1, 6);
                fuerza = random.Next(1, 11);
                armadura = random.Next(1, 11);
                nivel = random.Next(1, 11);
                salud = 100;
                break;
        }
        CaracteristicasPersonaje caracteristicas = new CaracteristicasPersonaje(velocidad, armadura, fuerza, nivel, salud, destreza);

        Personaje nuevoPersonaje = new Personaje(datos, caracteristicas);
        return nuevoPersonaje;
    }

    /*Trata de obtener un usuario aleatorio de la API utilizando reintentos con retrasos exponenciales en caso de que se produzca el error de "demasiadas solicitudes". Si después de varios intentos no se puede obtener el usuario, retorna null */
    private static async Task<UsuarioAleatorio> ObtenerUsuarioAleatorioConRetries()
    {
        int delay = initialDelay;
        //intenta un maximo de maxRetries veces 
        for (int retry = 0; retry < maxRetries; retry++)
        {
            try
            {
                // intenta obtener usuario
                return await MiApi.GetGeneraUsuario();
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.TooManyRequests)
            {
                // verifica si el intento actual es el último para salir del bucle.
                if (retry == maxRetries - 1)
                {
                    return null;
                }
                // el código espera por un tiempo y aumenta la espera para el proximo intento 
                await Task.Delay(delay);
                delay *= 2; //exponencial 
            }
            catch
            {
                return null;
            }
        }
        return null; // Si falla después de todos los intentos
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

    private static string ObtenerNombreAleatorio()
    {
        List<string> ListaDeNombres = new List<string>
        {
        "Arthur", "Lancelot", "Guinevere", "Merlin", "Gawain", "Morgana", "Percival", "Lazaro", "Dehiara", "Xanthor"
        };

        int i = random.Next(ListaDeNombres.Count);
        return ListaDeNombres[i];
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

