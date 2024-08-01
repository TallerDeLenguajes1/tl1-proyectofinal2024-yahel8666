using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebApiProyecto; 
namespace miProyecto;

public class MiApi()
{
    public static async Task<UsuarioAleatorio> GetGeneraUsuario()
    {

        var url = "https://random-data-api.com/api/v2/users?size=1";

    
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        string responseBody = await response.Content.ReadAsStringAsync();
        UsuarioAleatorio usuario = JsonSerializer.Deserialize<UsuarioAleatorio>(responseBody);
        return usuario;
    }
}
