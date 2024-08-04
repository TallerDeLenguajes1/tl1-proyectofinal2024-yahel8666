namespace miProyecto;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PersonajesJson
{
    public void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
    {
        var opciones = new JsonSerializerOptions
        {
            WriteIndented = true //escribe Identado
        };
        string json = JsonSerializer.Serialize(personajes, opciones);
        File.WriteAllText(nombreArchivo, json);
    }

    public List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        if (Existe(nombreArchivo))
        {
            string jsonString = File.ReadAllText(nombreArchivo);
            var personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            if (personajes != null)
            {
                return personajes;
            }
        }
        return new List<Personaje>();
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