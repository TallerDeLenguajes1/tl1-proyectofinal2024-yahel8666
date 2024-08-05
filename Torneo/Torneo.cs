namespace miProyecto;
public class Torneo
{
    Visuales Visuales = new Visuales();
    public void InicioTorneo(Personaje miPersonaje, List<Personaje> listadoEnemigos)
    {
        Personaje Ganador;
        if (listadoEnemigos == null || listadoEnemigos.Count < 3)
        {
            Visuales.CentrarTexto("No hay suficientes enemigos para el combate.");
            return;
        }

        Ganador = PrimerRound(miPersonaje, listadoEnemigos[0]);
        if (Ganador == miPersonaje)
        {
            MejorarPersonaje(miPersonaje);
            Ganador = SegundoRound(miPersonaje, listadoEnemigos[1]);
            if (Ganador == miPersonaje)
            {
                MejorarPersonaje(miPersonaje);
                Ganador = FinalRound(miPersonaje, listadoEnemigos[2]);
                if (Ganador == miPersonaje)
                {
                    //se guarda miPersonaje en el historial de ganadores. 
                }
                else
                {
                    // se guarda el oponente en el historial de ganadores. 
                }
            }
            else
            {
                // se guarda al enemigo como ganador en el historial.
                // se sale de combate y se deja de jugar 
            }
        }
        else
        {
            // se sale del combate y se deja de jugar
            // se guarda al enemigo como ganador en el historial.
        }
    }

    private Personaje PrimerRound(Personaje miPersonaje, Personaje enemigo)
    {
        Visuales.MensajePrimerRound();
        Thread.Sleep(2000);
        Visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        Visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        Visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Thread.Sleep(2000);
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            Visuales.MensajeGanador();
        }
        else
        {
            Visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            Visuales.MensajeGameOver();
        }
        return Ganador;
    }

    private Personaje SegundoRound(Personaje miPersonaje, Personaje enemigo)
    {
        Visuales.MensajeSegundoRound();
        Thread.Sleep(2000); 
        Visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        Visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        Visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            Visuales.MensajeGanador();
        }
        else
        {
            Visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            Visuales.MensajeGameOver();
        }
        return Ganador;
    }

    private Personaje FinalRound(Personaje miPersonaje, Personaje enemigo)
    {
        
        Visuales.MensajeFinalRound();
        Thread.Sleep(2000); 
        Visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        Visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        Visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            Visuales.MensajeGanador();
        }
        else
        {
            Visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            Thread.Sleep(1000);
            Visuales.MensajeGameOver();
        }
        return Ganador;
    }

    //realiza el combate y devuelve el personaje ganador. 
    private Personaje RealizarCombate(Personaje miPersonaje, Personaje enemigo)
    {
        Personaje Ganador = null;
        //la salud es reiniciada en cada combate para ambos, para que estén en igualdad de condiciones. 
        miPersonaje.Caracteristicas.Salud = 100;
        enemigo.Caracteristicas.Salud = 100;

        while (miPersonaje.Caracteristicas.Salud > 0 && enemigo.Caracteristicas.Salud > 0)
        {
            TurnoAtaque(miPersonaje, enemigo); //ataca y baja la salud del defensor
            if (enemigo.Caracteristicas.Salud <= 0)
            {
                Ganador = miPersonaje;
                break;
            }
            TurnoAtaque(enemigo, miPersonaje);
            if (miPersonaje.Caracteristicas.Salud <= 0)
            {
                Ganador = enemigo;
                break;
            }
        }
        return Ganador;
    }
    private void TurnoAtaque(Personaje atacante, Personaje defensor)
    {
        Random random = new Random();
        const int constanteAjuste = 500;

        int efectividad = random.Next(1, 101);
        int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza * atacante.Caracteristicas.Nivel;
        int defensa = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
        int dañoProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;
        dañoProvocado = Math.Max(0, dañoProvocado); // El daño no puede ser negativo.
        defensor.Caracteristicas.Salud -= dañoProvocado;

        Visuales.CentrarTexto($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {dañoProvocado} de daño.");
    }

    private void MejorarPersonaje(Personaje personaje)
    {
        Random random = new Random();
        int mejoraCaracteristica = random.Next(1, 6);
        switch (mejoraCaracteristica)
        {
            case 1:
                personaje.Caracteristicas.Armadura += 1;
                Visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Armadura!");
                break;
            case 2:
                personaje.Caracteristicas.Fuerza += 1;
                Visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Fuerza!");
                break;
            case 3:
                personaje.Caracteristicas.Destreza += 1;
                Visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Destreza!");
                break;
            case 4:
                personaje.Caracteristicas.Velocidad += 1;
                Visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Velocidad!");
                break;
            case 5:
                personaje.Caracteristicas.Nivel += 1;
                Visuales.CentrarTexto($"{personaje.Datos.Nombre} ha subido de Nivel!");
                break;
            default:
                Visuales.CentrarTexto("No hay mejora.");
                break;
        }
    }
}