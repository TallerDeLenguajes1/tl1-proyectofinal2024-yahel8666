namespace miProyecto; 
public class Personaje
{
    //Campos
    CaracteristicasPersonaje caracteristicas;
    DatosPersonaje datos;

    //Uso propiedades set and get
    public CaracteristicasPersonaje Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    public DatosPersonaje Datos { get => datos; set => datos = value; }

    //Constructor que recibe parametros, me genera un personaje. 
    public Personaje(DatosPersonaje datos, CaracteristicasPersonaje caracteristicas)
    {
        this.datos = datos; 
        this.caracteristicas = caracteristicas; 
    }    
}
