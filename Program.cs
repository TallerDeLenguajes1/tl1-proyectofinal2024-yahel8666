using miProyecto;
using WebApiProyecto;

//instancias de clases: 
var personajesJson = new PersonajesJson();
var fabrica = new fabricaPersonajes();
var seleccionPersonaje = new SeleccionPersonaje();
var visuales = new Visuales();  
var nuevoTorneo = new Torneo();
var menu = new Menu(); 

List<Personaje> listadoDePersonajes;
List<Personaje> ListadoDeEnemigos;
Personaje personajeSeleccionado; 

string archivoJson = "archivoPersonajes.json";

menu.MostrarMenuInicio();
int opcionMenu = menu.ObtenerOpcion(); //lee una entrada y la valida.

//falta desarrollar switch y poner todo dentro de una clase juego. 

if (!personajesJson.Existe(archivoJson))
{
    listadoDePersonajes = new List<Personaje>();
    for (int i = 0; i < 10; i++)
    {
        listadoDePersonajes.Add(await fabrica.CrearPersonajeAleatorio());
    }
    personajesJson.GuardarPersonajes(listadoDePersonajes, archivoJson);
}
else
{
    listadoDePersonajes = personajesJson.LeerPersonajes(archivoJson);
}

visuales.MostrarListaDePersonajes(listadoDePersonajes, 10); 
personajeSeleccionado = seleccionPersonaje.elegirMiPersonaje(listadoDePersonajes);
visuales.MostrarUnPersonaje(personajeSeleccionado); 
ListadoDeEnemigos = seleccionPersonaje.ObtenerEnemigos(listadoDePersonajes);
nuevoTorneo.InicioTorneo(personajeSeleccionado, ListadoDeEnemigos); 

