using miProyecto;

public class Menu
{
    Visuales visuales = new Visuales();
    public void MostrarMenuInicio()
    {
        Console.Clear(); 
        visuales.CentrarTexto("====================================");
        visuales.CentrarTexto("           MENU PRINCIPAL           ");
        visuales.CentrarTexto("====================================");
        Console.WriteLine();
        MostrarOpcion("1", "Nueva Partida");
        MostrarOpcion("2", "Ver Ganadores Historicos");
        MostrarOpcion("3", "Salir");
        Console.WriteLine();
        visuales.CentrarTexto("====================================");
        Thread.Sleep(1000);
    }

    public void MostrarOpcion(string numero, string opcion)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Red;
        int espacios = (Console.WindowWidth - (numero.Length + opcion.Length + 4)) / 2;
        Console.Write(new string(' ', espacios) + $"{numero}. ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{opcion}");
        Console.ResetColor();
    }

    public int ObtenerOpcion(int max)
    {
        int opcion;
        bool valida;
        visuales.CentrarTexto($"Elija una opción entre 1 y {max}: ");
        do
        {
            string entrada = Console.ReadLine();
            valida = int.TryParse(entrada, out opcion) && opcion >= 1 && opcion <= max;
            if (!valida)
            {
                visuales.CentrarTexto($"Opción inválida. Por favor, ingrese un número entre 1 y {max}.");
            }
        } while (!valida);
        return opcion;
    }

    public void mostrarMenuAtaque()
    {
        visuales.CentrarTexto("====================================");
        visuales.CentrarTexto("         ATAQUES ESPECIALES        ");
        visuales.CentrarTexto("====================================");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("  1- Ataque de agua       ");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("  2- Ataque de fuego      ");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("  3- Ataque de aire       ");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("  4- Ataque de tierra     ");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("  5- No realizar un ataque");
        visuales.CentrarTexto("    especial              ");
        visuales.CentrarTexto("");
        visuales.CentrarTexto("====================================");
        Console.WriteLine();

    }
}