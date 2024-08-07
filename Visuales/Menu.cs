using miProyecto;

public class Menu
{
    Visuales visuales = new Visuales();
    public void MostrarMenuInicio()
    {
        Console.Clear(); 
        visuales.CentrarTexto("");
        visuales.CentrarTexto(" 《  MENU PRINCIPAL  》  ");
        visuales.CentrarTexto("");
        visuales.MostrarAColor("------------ ✦ ------------", ConsoleColor.DarkCyan);
        Console.WriteLine("");
        MostrarOpcion("1", "Nueva Partida");
        MostrarOpcion("2", "Ver Ganadores Historicos");
        MostrarOpcion("3", "Salir");
        Console.WriteLine("");
        visuales.MostrarAColor("----------------------------",  ConsoleColor.DarkCyan);
        Thread.Sleep(1000);
    }

    public void MostrarOpcion(string numero, string opcion)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                visuales.MostrarAColor($"Opción inválida. Por favor, ingrese un número entre 1 y {max}.", ConsoleColor.DarkRed);
            }
        } while (!valida);
        return opcion;
    }

    public void mostrarMenuAtaque()
    { 
        Console.WriteLine();
        visuales.MostrarAColor("     ATAQUES ESPECIALES    ", ConsoleColor.White);
        visuales.MostrarAColor("------------ ✦ -------------", ConsoleColor.DarkCyan);
        MostrarOpcion("1", "Ataque de agua - mas fuerza, menos armadura");
        MostrarOpcion("2", "Ataque de fuego - mas destreza, menos velocidad");
        MostrarOpcion("3", "Ataque de aire - mas nivel, menos armadura");
        MostrarOpcion("4", "Ataque de tierra - mas fuerza, menos velocidad");
        MostrarOpcion("5", "No realizar un ataque especial");
        Console.WriteLine();
        visuales.MostrarAColor("----------------------------",  ConsoleColor.DarkCyan);
        Thread.Sleep(1000);
    }
}