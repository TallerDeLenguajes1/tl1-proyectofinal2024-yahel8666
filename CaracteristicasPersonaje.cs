namespace miProyecto; 
public class CaracteristicasPersonaje
{
    int velocidad;
    int rapidez;
    int fuerza;
    int nivel;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Rapidez { get => rapidez; set => rapidez = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }

    //Constructor de caracteristicas que recibe parametros.
    public CaracteristicasPersonaje(int velocidad, int rapidez, int fuerza, int nivel)
    {
        this.Velocidad = velocidad;
        this.Rapidez = rapidez;
        this.Fuerza = fuerza;
        this.Nivel = nivel;
    }

   
}
