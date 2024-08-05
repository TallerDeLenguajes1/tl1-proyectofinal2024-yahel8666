using miProyecto;

public class Menu
{
    Visuales Visuales = new Visuales();
    public void MostrarMenuInicio()
    {
        Console.Clear(); // Limpiar la pantalla antes de mostrar el menú
        Visuales.CentrarTexto("====================================");
        Visuales.CentrarTexto("           MENU PRINCIPAL           ");
        Visuales.CentrarTexto("====================================");
        Console.WriteLine();
        MostrarOpcion("1", "Iniciar Juego");
        MostrarOpcion("2", "Opciones");
        MostrarOpcion("3", "Salir");
        Console.WriteLine();
        Visuales.CentrarTexto("====================================");
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

    public int ObtenerOpcion()
    {
        int opcion;
        bool valida;
        Visuales.CentrarTexto("Elija una opción (1-3): ");
        do
        {
            string entrada = Console.ReadLine();
            valida = int.TryParse(entrada, out opcion) && opcion >= 1 && opcion <= 3;
            if (!valida)
            {
                Visuales.CentrarTexto("Opción inválida. Por favor, ingrese un número entre 1 y 3.");
            }
        } while (!valida);
        return opcion;
    }
}