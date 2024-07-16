using WebApiProyecto;
namespace miProyecto;


public class fabricaPersonajes()
{
    private static Random random = new Random();
    // Método estático y asíncrono para crear un personaje aleatorio
    public static async Task<Personaje> CrearPersonajeAleatorio()
    {
        // Llamada a una API para obtener un usuario aleatorio
        UsuarioAleatorio usuarioAleatorio = await MiApi.GetGeneraUsuario();

        // Extraer el nombre del usuario aleatorio obtenido
        string nombre = usuarioAleatorio.first_name;

        TiposPersonajes tiposPersonajes = new TiposPersonajes();
        string tipo = tiposPersonajes.obtenerTipoAleatorio();

        DateTime fechaNac = ObtenerFechaAleatoria();
        int edad = CalcularEdad(fechaNac);

        // Crear un objeto DatosPersonaje con la información obtenida. 
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

