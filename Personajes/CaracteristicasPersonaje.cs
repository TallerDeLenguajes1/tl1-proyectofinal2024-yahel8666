namespace miProyecto; 
public class CaracteristicasPersonaje
{
    int velocidad;
    int destreza; 
    int fuerza;
    int armadura; 
    int nivel;
    int salud;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Destreza { get => destreza; set => destreza = value; }

    //Constructor de caracteristicas que recibe parametros.
    public CaracteristicasPersonaje(int velocidad, int armadura, int fuerza , int nivel, int salud, int destreza )
    {
        this.velocidad = velocidad;
        this.armadura = armadura; 
        this.fuerza = fuerza;
        this.nivel = nivel;
        this.salud = salud; 
        this.destreza = destreza; 
    }
}
