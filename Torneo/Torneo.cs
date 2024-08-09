namespace miProyecto;
public class Torneo
{
    Visuales visuales = new Visuales();
    Menu menu = new Menu();
    Sonido sonido = new Sonido(); 
    public async Task InicioTorneo(Personaje miPersonaje, List<Personaje> listadoEnemigos)
    {
        Personaje Ganador;
        string archivoGanadores = "HistorialGanadores.json";
        var historial = new HistorialJson();
        var fabrica = new fabricaPersonajes();

        //control - en caso de que no haya suficientes enemigos, los crea. (muy poco probable)
        if (listadoEnemigos == null || listadoEnemigos.Count < 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Personaje nuevoEnemigo = await fabrica.CrearPersonajeAleatorio();
                listadoEnemigos.Add(nuevoEnemigo);
            }
        } 

        //PRIMER ROUND
        sonido.ReproducirSonidoBucle("Media/pelea.wav");
        sonido.ReproducirSonido("Media/nuevoRound.wav");
        visuales.MensajePrimerRound();
        Ganador = PelarRound(miPersonaje, listadoEnemigos[0]);
        if (Ganador == miPersonaje)
        {
            MejorarPersonaje(miPersonaje);
                     //SEGUNDO ROUND
            sonido.ReproducirSonido("Media/nuevoRound.wav");
            visuales.MensajeSegundoRound();
            Ganador = PelarRound(miPersonaje, listadoEnemigos[1]);
            if (Ganador == miPersonaje)
            {
                MejorarPersonaje(miPersonaje);
                    // TERCER ROUND
                sonido.ReproducirSonido("Media/nuevoRound.wav");
                visuales.MensajeFinalRound();
                Ganador = PelarRound(miPersonaje, listadoEnemigos[2]);
                if (Ganador == miPersonaje)
                {
                    sonido.PararSonidoBucle();
                    sonido.ReproducirSonido("Media/ganador.wav");
                    visuales.MensajeGanadorFinal();
                    historial.GuardarGanador(miPersonaje, archivoGanadores);
                }
                else
                {
                    visuales.MensajePerdedor();
                    Console.Clear();
                    sonido.PararSonidoBucle(); 
                    sonido.ReproducirSonido("Media/gameOver.wav"); 
                    visuales.MensajeGameOver();
                    historial.GuardarGanador(listadoEnemigos[2], archivoGanadores);
                }
            }
            else
            {   
                sonido.PararSonidoBucle(); 
                sonido.ReproducirSonido("Media/gameOver.wav"); 
                visuales.MensajeGameOver();
                historial.GuardarGanador(listadoEnemigos[1], archivoGanadores);
            }
        }
        else
        {
            sonido.PararSonidoBucle(); 
            sonido.ReproducirSonido("Media/gameOver.wav"); 
            visuales.MensajeGameOver();
            historial.GuardarGanador(listadoEnemigos[0], archivoGanadores);
        }
    }

    private Personaje PelarRound(Personaje miPersonaje, Personaje enemigo)
    {
        Console.Clear();
        PresentacionLuchadores(miPersonaje, enemigo);
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        Thread.Sleep(1000);
        if (Ganador == miPersonaje)
        {
            visuales.MensajeGanador();
        }
        else
        {
            visuales.MensajePerdedor();
            Console.Clear();
        }
        return Ganador;
    }
    //realiza el combate y devuelve el personaje ganador. 
    private Personaje RealizarCombate(Personaje miPersonaje, Personaje enemigo)
    {
        Personaje Ganador = null;
        miPersonaje.Caracteristicas.Salud = 100;
        enemigo.Caracteristicas.Salud = 100;
        int medidor = 0;
        while (miPersonaje.Caracteristicas.Salud > 0 && enemigo.Caracteristicas.Salud > 0)
        {
            medidor++;
            if (medidor % 4 == 0) //cada 3 turnos, se le da la opcion de elegir un ataque especial.
            {
                MiAtaqueEspecial(miPersonaje, enemigo);
                if (enemigo.Caracteristicas.Salud <= 0)
                {
                    Ganador = miPersonaje;
                    break;
                }
            } else  {
                TurnoAtaque(miPersonaje, enemigo, ConsoleColor.Green); //ataca miPersonaje 
                if (enemigo.Caracteristicas.Salud <= 0)
                {
                    Ganador = miPersonaje;
                    break;
                }
            }
            TurnoAtaque(enemigo, miPersonaje, ConsoleColor.Red); //ataca enemigo
            if (miPersonaje.Caracteristicas.Salud <= 0)
            {
                Ganador = enemigo;
                break;
            }
        }
        return Ganador;
    }
    private void TurnoAtaque(Personaje atacante, Personaje defensor, ConsoleColor color)
    {
        Random random = new Random();
        const int constanteAjuste = 500;

        int efectividad = random.Next(1, 101);
        int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
        int defensa = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
        int dañoProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;
        dañoProvocado = Math.Max(0, dañoProvocado);
        defensor.Caracteristicas.Salud -= dañoProvocado;

        visuales.MostrarAColor(".............. ", color);
        visuales.CentrarTexto($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {dañoProvocado} de daño.");
        visuales.MostrarAColor("..............", color);
        Thread.Sleep(1000);
    }

    private void MejorarPersonaje(Personaje personaje)
    {
        Random random = new Random();
        int mejoraCaracteristica = random.Next(1, 6);
        int puntosDeMejora = random.Next(1, 4);
        switch (mejoraCaracteristica)
        {
            case 1:
                personaje.Caracteristicas.Armadura += puntosDeMejora;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado {puntosDeMejora} puntos su Armadura!");
                break;
            case 2:
                personaje.Caracteristicas.Fuerza += puntosDeMejora;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado {puntosDeMejora} puntos su Fuerza!");
                break;
            case 3:
                personaje.Caracteristicas.Destreza += puntosDeMejora;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado {puntosDeMejora} puntos su Destreza!");
                break;
            case 4:
                personaje.Caracteristicas.Velocidad += puntosDeMejora;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado {puntosDeMejora} puntos su Velocidad!");
                break;
            case 5:
                personaje.Caracteristicas.Nivel += puntosDeMejora;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha subido {puntosDeMejora} puntos de Nivel!");
                break;
            default:
                visuales.CentrarTexto("No hay mejora.");
                break;
        }
        visuales.MostrarAColor(".....................", ConsoleColor.DarkCyan);
        Thread.Sleep(2500);
    }

    private void MiAtaqueEspecial(Personaje atacante, Personaje defensor)
    {
        int opcionAtaque;
        menu.mostrarMenuAtaque();
        opcionAtaque = menu.ObtenerOpcion(5);
        switch (opcionAtaque)
        {
            case 1:
                visuales.MostrarAColor($"✧ {atacante.Datos.Nombre} realiza un ataque de agua ✧", ConsoleColor.DarkCyan); atacante.Caracteristicas.Fuerza += 3;
                atacante.Caracteristicas.Armadura -= 2;
                break;
            case 2:
                visuales.MostrarAColor($"✧ {atacante.Datos.Nombre} realiza un ataque de fuego ✧", ConsoleColor.DarkCyan); atacante.Caracteristicas.Destreza += 2;
                atacante.Caracteristicas.Velocidad -= 1;
                break;
            case 3:
                visuales.MostrarAColor($"✧ {atacante.Datos.Nombre} realiza un ataque de aire ✧", ConsoleColor.DarkCyan);
                atacante.Caracteristicas.Nivel += 1;
                atacante.Caracteristicas.Armadura -= 3;
                break;
            case 4:
                visuales.MostrarAColor($"✧ {atacante.Datos.Nombre} realiza un ataque de tierra ✧", ConsoleColor.DarkCyan);
                atacante.Caracteristicas.Fuerza += 3;
                atacante.Caracteristicas.Velocidad -= 2;
                break;
            case 5:
                visuales.MostrarAColor($"✧ {atacante.Datos.Nombre} decide no realizar un ataque especial ✧", ConsoleColor.DarkCyan);
                break;
        }
        Thread.Sleep(1000);
        TurnoAtaque(atacante, defensor, ConsoleColor.DarkGreen);
    }

    private void PresentacionLuchadores(Personaje miPersonaje, Personaje enemigo)
    {
        Console.WriteLine("");
        Console.WriteLine("");
        visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        visuales.MostrarAColor("VS", ConsoleColor.DarkCyan);
        Thread.Sleep(1000);
        visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Thread.Sleep(2000);
    }
}