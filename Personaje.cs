namespace miProyecto; 
public class Personaje
{
    //Campos: 
    CaracteristicasPersonaje caracteristicas;
    DatosPersonaje datos;

    //Uso propiedades set and get: 
    public CaracteristicasPersonaje Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    public DatosPersonaje Datos { get => datos; set => datos = value; }

    //Constructor que recibe parametros, me genera un personaje:  
    public Personaje(DatosPersonaje datos, CaracteristicasPersonaje caracteristicas)
    {
        this.datos = datos; 
        this.caracteristicas = caracteristicas; 
    }   

    //Metodo para mostrar personaje
    public void MostrarPersonaje()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("            DETALLES DEL PERSONAJE      ");
        Console.WriteLine("========================================");
        Console.WriteLine($"Nombre:           {Datos.Nombre}");
        Console.WriteLine($"Tipo:             {Datos.Tipo}");
        Console.WriteLine($"Fecha de Nac:     {Datos.FechaNac.ToShortDateString()}");
        Console.WriteLine($"Edad:             {Datos.Edad}");
        Console.WriteLine("========================================");
        Console.WriteLine("           CARACTERÍSTICAS               ");
        Console.WriteLine("========================================");
        Console.WriteLine($"Velocidad:        {Caracteristicas.Velocidad}");
        Console.WriteLine($"Armadura:         {Caracteristicas.Armadura}");
        Console.WriteLine($"Rapidez:          {Caracteristicas.Rapidez}");
        Console.WriteLine($"Fuerza:           {Caracteristicas.Fuerza}");
        Console.WriteLine($"Nivel:            {Caracteristicas.Nivel}");
        Console.WriteLine($"Salud:            {Caracteristicas.Salud}");
        Console.WriteLine($"Destreza:         {Caracteristicas.Destreza}");
        Console.WriteLine("========================================");
    }
}


