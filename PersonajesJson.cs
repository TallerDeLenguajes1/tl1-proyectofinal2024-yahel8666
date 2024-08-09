namespace miProyecto;
using System.IO;
using System.Text.Json;

public class PersonajesJson
{
    public void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        var opcion = new JsonSerializerOptions
        {
            WriteIndented = true //escribe Identado
        };
        string json = JsonSerializer.Serialize(personajes, opcion);
        File.WriteAllText(nombreArchivo, json);
    }

    public List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        List<Personaje> listadoPersonajes = new List<Personaje>();  
        if (Existe(nombreArchivo))
        {
            string jsonString = File.ReadAllText(nombreArchivo);
            var personajesDeserializados = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            listadoPersonajes = personajesDeserializados;
        } 
        return listadoPersonajes;
    }

    public bool Existe(string nombreArchivo)
    {
        FileInfo archivo = new FileInfo(nombreArchivo);
        if (File.Exists(nombreArchivo) && archivo.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}