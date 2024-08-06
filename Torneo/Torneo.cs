namespace miProyecto;
public class Torneo
{
    Visuales visuales = new Visuales();
    Menu menu  = new Menu();
    public void InicioTorneo(Personaje miPersonaje, List<Personaje> listadoEnemigos)
    {
        Personaje Ganador;
        string archivoGanadores = "HistorialGanadores.json";
        var historial = new HistorialJson(); 

        if (listadoEnemigos == null || listadoEnemigos.Count < 3)
        {
            visuales.CentrarTexto("No hay suficientes enemigos para el combate.");
            return;
        }

        //Explicacion de la modalidad del juego. 
        Ganador = PrimerRound(miPersonaje, listadoEnemigos[0]);
        if (Ganador == miPersonaje) {
            MejorarPersonaje(miPersonaje);
            Ganador = SegundoRound(miPersonaje, listadoEnemigos[1]);
            if (Ganador == miPersonaje) {
                MejorarPersonaje(miPersonaje);
                Ganador = FinalRound(miPersonaje, listadoEnemigos[2]);
                if (Ganador == miPersonaje) {
                    historial.GuardarGanador(miPersonaje, archivoGanadores); 
                } else {
                    historial.GuardarGanador(listadoEnemigos[2], archivoGanadores); 
                }
            } else {
                historial.GuardarGanador(listadoEnemigos[1], archivoGanadores); 
            }
        } else {
            historial.GuardarGanador(listadoEnemigos[0], archivoGanadores); 
        }
    }

    private Personaje PrimerRound(Personaje miPersonaje, Personaje enemigo)
    {
        Console.Clear(); 
        visuales.MensajePrimerRound();
        Thread.Sleep(2000);
        visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Thread.Sleep(2000);
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            visuales.MensajeGanador();
            Thread.Sleep(3000);
        }
        else
        {
            visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            visuales.MensajeGameOver();
            Thread.Sleep(3000);
        }
        return Ganador;
    }

    private Personaje SegundoRound(Personaje miPersonaje, Personaje enemigo)
    {
        Console.Clear(); 
        visuales.MensajeSegundoRound();
        Thread.Sleep(2000); 
        visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Thread.Sleep(2000);
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            visuales.MensajeGanador();
            Thread.Sleep(2000);
        }
        else
        {
            visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            visuales.MensajeGameOver();
            Thread.Sleep(3000);
        }
        return Ganador;
    }

    private Personaje FinalRound(Personaje miPersonaje, Personaje enemigo)
    {
        Console.Clear(); 
        visuales.MensajeFinalRound();
        Thread.Sleep(2000); 
        visuales.CentrarTexto($"{miPersonaje.Datos.Nombre}");
        Thread.Sleep(1000);
        visuales.CentrarTexto("VS");
        Thread.Sleep(1000);
        visuales.CentrarTexto($"{enemigo.Datos.Nombre}");
        Thread.Sleep(2000);
        Personaje Ganador = RealizarCombate(miPersonaje, enemigo);
        if (Ganador == miPersonaje)
        {
            visuales.MensajeGanadorFinal();
            Thread.Sleep(3000);
        }
        else
        {
            visuales.MensajePerdedor();
            Thread.Sleep(2000);
            Console.Clear();
            visuales.MensajeGameOver();
            Thread.Sleep(3000);
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
        int medidor=0;
        while (miPersonaje.Caracteristicas.Salud > 0 && enemigo.Caracteristicas.Salud > 0)
        {
            medidor++; 
            if (medidor%4==0) //cada 5 turnos, se le da la opcion de elegir un ataque especial.
            {
                miAtaqueEspecial(miPersonaje, enemigo);
                if (enemigo.Caracteristicas.Salud <= 0)
                {
                    Ganador = miPersonaje;
                    break;
                }
            } else {    
                TurnoAtaque(miPersonaje, enemigo); //ataca y baja la salud del defensor
                if (enemigo.Caracteristicas.Salud <= 0)
                {
                    Ganador = miPersonaje;
                    break;
                }
            }
            //ataque enemigo. 
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
        dañoProvocado = Math.Max(0, dañoProvocado); 
        defensor.Caracteristicas.Salud -= dañoProvocado;

        visuales.CentrarTexto($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {dañoProvocado} de daño.");
        Thread.Sleep(1000);
    }

    private void MejorarPersonaje(Personaje personaje)
    {
        Random random = new Random();
        int mejoraCaracteristica = random.Next(1, 6);
        switch (mejoraCaracteristica)
        {
            case 1:
                personaje.Caracteristicas.Armadura += 1;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Armadura!");
                Thread.Sleep(2000);
                break;
            case 2:
                personaje.Caracteristicas.Fuerza += 1;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Fuerza!");
                Thread.Sleep(2000);
                break;
            case 3:
                personaje.Caracteristicas.Destreza += 1;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Destreza!");
                Thread.Sleep(2000);
                break;
            case 4:
                personaje.Caracteristicas.Velocidad += 1;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha mejorado su Velocidad!");
                Thread.Sleep(2000);
                break;
            case 5:
                personaje.Caracteristicas.Nivel += 1;
                visuales.CentrarTexto($"{personaje.Datos.Nombre} ha subido de Nivel!");
                Thread.Sleep(2000);
                break;
            default:
                visuales.CentrarTexto("No hay mejora.");
                Thread.Sleep(2000);
                break;
        }
    }

    private void miAtaqueEspecial(Personaje atacante, Personaje defensor)
    {
        int opcionAtaque;
        menu.mostrarMenuAtaque();
        opcionAtaque = menu.ObtenerOpcionAtaque();
        switch (opcionAtaque)
        {
            case 1: 
            visuales.CentrarTexto($"{atacante.Datos.Nombre} realiza un ataque de agua");
            atacante.Caracteristicas.Fuerza +=3; 
            atacante.Caracteristicas.Armadura-=2;
            break;
            case 2: 
            visuales.CentrarTexto($"{atacante.Datos.Nombre} realiza un ataque de fuego");
            atacante.Caracteristicas.Destreza +=2; 
            atacante.Caracteristicas.Velocidad-=1;
            break;
            case 3: 
            visuales.CentrarTexto($"{atacante.Datos.Nombre} realiza un ataque de aire");
            atacante.Caracteristicas.Nivel +=1; 
            atacante.Caracteristicas.Armadura-=3;
            break;
            case 4: 
            visuales.CentrarTexto($"{atacante.Datos.Nombre} realiza un ataque de tierra");
            atacante.Caracteristicas.Fuerza +=3; 
            atacante.Caracteristicas.Velocidad-=2;
            break;
            case 5: 
            visuales.CentrarTexto($"{atacante.Datos.Nombre} decide no realizar un ataque especial");
            break;
        }
        TurnoAtaque(atacante, defensor);
    }
}