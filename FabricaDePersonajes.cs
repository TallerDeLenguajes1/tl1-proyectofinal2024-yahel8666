namespace miProyecto; 
using WebApiProyecto;

public class fabricaPersonajes()
{
    private static Random random = new Random();

    // Método estático y asíncrono para crear un personaje aleatorio
    public static async Task<Personaje> CrearPersonajeAleatorio()
    {
        // Llamada a una API para obtener un usuario aleatorio
        UsuarioAleatorio usuarioAleatorio = await MiApi.GetGeneraUsuario();

        // Extraer el nombre y el apodo del usuario aleatorio obtenido
        string nombre = usuarioAleatorio.first_name;

        // Crear una instancia de TiposPersonajes y obtener un tipo aleatorio de personaje
        TiposPersonajes tiposPersonajes = new TiposPersonajes();
        string tipo = tiposPersonajes.obtenerTipoAleatorio();

        // Obtener una fecha de nacimiento aleatoria
        DateTime fechaNac = ObtenerFechaAleatoria();

        // Calcular la edad a partir de la fecha de nacimiento
        int edad = CalcularEdad(fechaNac);

        // Crear un objeto DatosPersonaje con la información obtenida. 
        DatosPersonaje datos = new DatosPersonaje(nombre, tipo, fechaNac, edad);

        // Generar valores aleatorios para las características del personaje
        int velocidad = random.Next(1, 101);
        int destreza = random.Next(1, 101);
        int rapidez = random.Next(1, 101);
        int fuerza = random.Next(1, 101);
        int armadura = random.Next(1, 101);
        int nivel = random.Next(1, 101);
        int salud = random.Next(1, 101);

        // Crear un objeto CaracteristicasPersonaje con los valores generados
        CaracteristicasPersonaje caracteristicas = new CaracteristicasPersonaje(velocidad, armadura, rapidez, fuerza, nivel, salud, destreza);

        // Devolver un nuevo objeto Personaje con los datos y características creados
        return new Personaje(datos, caracteristicas);
    }

    // Método para obtener una fecha aleatoria entre el 1 de enero de 1950 y hoy
    private static DateTime ObtenerFechaAleatoria()
    {
        DateTime start = new DateTime(1950, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(random.Next(range));
    }

    // Método para calcular la edad a partir de una fecha de nacimiento
    private static int CalcularEdad(DateTime fechaNac)
    {
        int edad = DateTime.Today.Year - fechaNac.Year;
        if (fechaNac.Date > DateTime.Today.AddYears(-edad)) edad--;
        return edad;
    }
}

