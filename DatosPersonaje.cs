namespace miProyecto; 
public class DatosPersonaje
{
    // Propiedades públicas para los datos del personaje
    string nombre;
    string tipo;
    int anioNacimiento;

    
    public string Nombre { get => nombre; set => nombre = value; }
    public string Tipo { get => tipo; set => tipo = value; }
    public int AnioNacimiento { get => anioNacimiento; set => anioNacimiento = value; }
    
    public DatosPersonaje(string nombre, string tipo, int anioNacimiento)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.anioNacimiento = anioNacimiento;
    }

}
    // Constructor para inicializar las propiedades
