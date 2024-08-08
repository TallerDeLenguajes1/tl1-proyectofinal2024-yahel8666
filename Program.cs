using miProyecto;
using WebApiProyecto;
//_____________________; 
//instancias de clases: 
var personajesJson = new PersonajesJson();
var fabrica = new fabricaPersonajes();
var seleccionPersonaje = new SeleccionPersonaje();
var visuales = new Visuales();
var nuevoTorneo = new Torneo();
var menu = new Menu();
var historial = new HistorialJson();
var texto = new Texto();

List<Personaje> listadoDePersonajes;
List<Personaje> ListadoDeEnemigos;
List<Ganador> listadoGanadores;
Personaje personajeSeleccionado;
string archivoJson = "archivoPersonajes.json";
string archivoGanadores = "HistorialGanadores.json";


visuales.Titulo();
// texto.MensajePresentacion();
int opcionMenu;
do
{
    menu.MostrarMenuInicio();
    opcionMenu = menu.ObtenerOpcion(3);
    switch (opcionMenu)
    {
        case 1:
            if (!personajesJson.Existe(archivoJson))
            {
                listadoDePersonajes = new List<Personaje>();
                for (int i = 0; i < 10; i++)
                {
                    /*aclaracion: debido al delay que tiene el metodo para obtener un 
                    usuario de la API, crear 10 personajes aletoriamente conectandose a 
                    la api toma unos segundos, pero funciona. */
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
            await texto.MensajeObteniendoEnemigos();
            ListadoDeEnemigos = seleccionPersonaje.ObtenerEnemigos(listadoDePersonajes);
            // texto.MensajeNuevoTorneo();
            await nuevoTorneo.InicioTorneo(personajeSeleccionado, ListadoDeEnemigos);
            break;
        case 2:
            listadoGanadores = historial.LeerGanadores(archivoGanadores);
            visuales.MostrarHistorialGanadores(listadoGanadores);
            break;
        case 3:
            texto.MensajeDespedida();
            break;
    }
} while (opcionMenu != 3);



