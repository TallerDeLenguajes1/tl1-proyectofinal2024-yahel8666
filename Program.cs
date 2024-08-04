using miProyecto;
using WebApiProyecto;

//texto.Logo
//texto.Introduccion
//muestro menú con opciones. 


var personajesJson = new PersonajesJson();
var fabrica = new fabricaPersonajes();
var Visuales = new Visuales();
List<Personaje> listadoDePersonajes;
string archivoJson = "archivoPersonajes.json";

//asumo primera opcion - Nueva Partida
//creo o obtengo los personajes 
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

//muestro los personajes creados/obtenidos 
Visuales.MostrarListaDePersonajes(listadoDePersonajes, 10);

//El usuario selecciona su personaje, este se elimina de la lista. 
SeleccionPersonaje seleccionPersonaje = new SeleccionPersonaje();
Personaje personajeSeleccionado = seleccionPersonaje.elegirMiPersonaje(listadoDePersonajes);
Visuales.CentrarTexto("Personaje elegido: ");
Visuales.MostrarUnPersonaje(personajeSeleccionado);

//Se eligen 3 personajes aleatorios que serán los enemigos. Cada vez que se elije uno, se elimna de la lista
List<Personaje> ListadoDeEnemigos = seleccionPersonaje.ObtenerEnemigos(listadoDePersonajes);

//vamos a la logica del combate... 
Torneo nuevoTorneo = new Torneo(); 
// nuevoTorneo.inicioCombate(personajeSeleccionado, ListadoDeEnemigos); 






