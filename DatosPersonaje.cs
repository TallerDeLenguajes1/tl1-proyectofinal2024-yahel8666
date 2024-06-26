namespace miProyecto; 
public class DatosPersonaje
{
    string nombre;
    string tipo;
    DateTime fechaNac;
    int edad; 

    public string Nombre { get => nombre; set => nombre = value; }
    public string Tipo { get => tipo; set => tipo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }

    public DatosPersonaje(string nombre, string tipo, DateTime fechaNac, int edad)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.fechaNac = fechaNac;
        this.edad = edad; 
    }

}

