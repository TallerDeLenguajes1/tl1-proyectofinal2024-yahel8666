namespace miProyecto;
using System.Text.Json;
public class HistorialJson
{
    public void GuardarGanador(Personaje personajeGanador, string nombreArchivo)
    {
        List<Ganador> listadoGanadores = new List<Ganador>();

        //creo el objeto ganador con las caractersticas que quiero guardar. 
        Ganador nuevoGanador = new Ganador(personajeGanador.Datos.Nombre,
                                            personajeGanador.Datos.Tipo,
                                            personajeGanador.Caracteristicas.Salud, 
                                            personajeGanador.Caracteristicas.Nivel
                                            );

        if (Existe(nombreArchivo))
        {
            listadoGanadores = LeerGanadores(nombreArchivo);
        }

        listadoGanadores.Add(nuevoGanador);
        var opcion = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(listadoGanadores, opcion);
        File.WriteAllText(nombreArchivo, jsonString);
    }

    public List<Ganador> LeerGanadores(string archivoGanadores)
    {
        if (Existe(archivoGanadores))
        {
            string jsonString = File.ReadAllText(archivoGanadores);
            var ganadores = JsonSerializer.Deserialize<List<Ganador>>(jsonString);
            if (ganadores != null)
            {
                return ganadores;
            }
        }
        return new List<Ganador>();
    }

    public bool Existe(string nombreArchivo)
    {
        FileInfo archivo = new FileInfo(nombreArchivo);
        return File.Exists(nombreArchivo) && archivo.Length > 0;
    }
}

//clase con los atributos que quiero que se guarden. (no quiero que se guarde todo el personaje).
public class Ganador
{
    private string nombre;
    private string tipo; 
    private int salud;
    private int nivel;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Tipo { get => tipo; set => tipo = value; }
    public int Salud { get => salud; set => salud = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    // Constructor que recibe todos los parámetros
    public Ganador(string nombre, string tipo, int salud, int nivel)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.salud = salud;
        this.nivel = nivel;
    }
}