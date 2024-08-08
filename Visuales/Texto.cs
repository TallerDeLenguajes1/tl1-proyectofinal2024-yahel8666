namespace miProyecto;
public class Texto
{
    Visuales visuales = new Visuales();
    
    public void MensajePresentacion()
    {
        string presentacion = "¡Bienvenidos a Final Fighter! En este juego, tendrás la oportunidad de convertirte en un héroe. Elige a tu personaje favorito y prepárate para enfrentarte a tres oponentes seleccionados aleatoriamente. La batalla continuará hasta que ganes todos los combates o hasta que caigas en la arena. Cada ronda te ofrece la oportunidad de realizar un ataque especial que incrementará tu poder de ataque, aunque a costa de tu defensa en el próximo turno. Estos ataques especiales están basados en los poderosos elementos de la naturaleza. Podrás elegir entre: Ataque de Aire, Fuego, Agua, y Tierra. Si sales victorioso, tu nombre será inmortalizado en la lista de ganadores históricos. ¡Prepárate para la gloria y que comience la batalla!";

        EscribirLento(presentacion);
        Thread.Sleep(2000);
        visuales.MostrarAColor("Presione una tecla para continuar...", ConsoleColor.DarkGray);
        Console.ReadKey();

    }

    public void MensajeDespedida()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        visuales.CentrarTexto("Esperamos que te hayas divertido!");
        Thread.Sleep(1000);
        visuales.MostrarAColor("Hasta Pronto", ConsoleColor.DarkCyan);
        Thread.Sleep(1000);
        AdiosASCII();
        Thread.Sleep(2000);
    }

    private void EscribirLento(string mensaje)
    {
        foreach (char c in mensaje)
        {
            Console.Write(c);
            Thread.Sleep(20); // Pausa entre cada carácter
        }
        Console.WriteLine();
    }

    private async Task Cargando()
    { 
        int anchoPantalla = Console.WindowWidth;
        string puntos = "";
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 3; i++)
            {

                switch (i % 3)
                {
                    case 0:
                        puntos = ".";
                        break;
                    case 1:
                        puntos = "..";
                        break;
                    case 2:
                        puntos = "...";
                        break;
                }

                int anchoTexto = puntos.Length;
                int espacioLateral = (anchoPantalla - anchoTexto) / 2;


            Console.SetCursorPosition(espacioLateral, Console.CursorTop + 1);
            Console.ForegroundColor = ConsoleColor.Yellow; // Cambia el color a amarillo
            Console.Write(puntos);
            Console.ResetColor(); // Restablece el color original
            await Task.Delay(500);
                // Mueve el cursor a la posición específica sin borrar la pantalla
    

                // Borra los puntos anteriores
                Console.SetCursorPosition(espacioLateral, Console.CursorTop);
                Console.Write(new string(' ', puntos.Length));
                Console.SetCursorPosition(espacioLateral, Console.CursorTop - 1);
            }
        }
    }
    public async Task MensajeObteniendoEnemigos()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        visuales.CentrarTexto("Ahora vamos a elegir a tus enemigos");
        visuales.MostrarAColor("--------------", ConsoleColor.DarkCyan);
        Thread.Sleep(1200);
        await Cargando();
        Console.WriteLine("");
        visuales.CentrarTexto("Todo listo! Que empiece el combate");
        Thread.Sleep(2000);
        Console.WriteLine("");
        visuales.MostrarAColor("Buena Suerte!", ConsoleColor.DarkCyan);
        Thread.Sleep(2500);
    }
    private void AdiosASCII()
    {
            string bye = @"
     ███████████  █████ █████ ██████████   ███
    ░░███░░░░░███░░███ ░░███ ░░███░░░░░█  ░███
     ░███    ░███ ░░███ ███   ░███  █ ░   ░███
     ░██████████   ░░█████    ░██████     ░███
     ░███░░░░░███   ░░███     ░███░░█     ░███
     ░███    ░███    ░███     ░███ ░   █  ░░░ 
     ███████████     █████    ██████████   ███
    ░░░░░░░░░░░     ░░░░░    ░░░░░░░░░░   ░░░ 
            ";

          visuales.CentrarASCII(bye);
    }


}