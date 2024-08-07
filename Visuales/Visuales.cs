namespace miProyecto;
public class Visuales
{
    private const int AnchoColumna = 30;
    private const int AnchoMarco = AnchoColumna + 18; // para márgenes
    public void CentrarTexto(string texto)
    {
        int anchoPantalla = Console.WindowWidth;
        int espaciosPrevios = (anchoPantalla - texto.Length) / 2;
        Console.WriteLine(new string(' ', Math.Max(0, espaciosPrevios)) + texto);
    }
    
    public void MostrarAColor(string mensaje, ConsoleColor color)
    {
        // Obtiene el ancho de la consola
        int anchoPantalla = Console.WindowWidth;

        // Calcula el espacio lateral necesario para centrar el mensaje
        int anchoMensaje = mensaje.Length;
        int espacioLateral = (anchoPantalla - anchoMensaje) / 2;

        // Configura el color
        Console.ForegroundColor = color;

        // Centra el mensaje
        Console.SetCursorPosition(espacioLateral, Console.CursorTop);
        Console.WriteLine(mensaje);

        // Restablece el color de la consola
        Console.ResetColor();
    }

    public void MostrarListaDePersonajes(List<Personaje> personajes, int cantidad)
    {
        if (personajes == null || personajes.Count == 0)
        {
            CentrarTexto("No hay personajes para mostrar.");
            return;
        }
        int indiceActual = 0;
        ConsoleKeyInfo teclaPresionada;
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarTexto("A continuacion, te mostramos los personajes disponibles para elegir: ");
        Thread.Sleep(2000);
        do
        {
            Console.Clear();
            MostrarPersonaje(personajes[indiceActual], indiceActual + 1);
            teclaPresionada = Console.ReadKey();
            if (teclaPresionada.Key == ConsoleKey.Enter)
            {
                indiceActual++;
                cantidad--;
            }

        } while (cantidad > 0 && teclaPresionada.Key == ConsoleKey.Enter); // Termina cuando se acaben los personajes
    }

    private void MostrarPersonaje(Personaje personaje, int numero)
    {
        // Crear un marco alrededor de la tabla
        string marcoSuperiorInferior = new string('=', AnchoMarco);
        string marcoMedio = new string('-', AnchoMarco);
        Console.WriteLine("");
        Console.WriteLine("");
        MostrarAColor(marcoSuperiorInferior, ConsoleColor.DarkCyan);
        CentrarTexto($"| {"Personaje",-12} | {numero,-AnchoColumna} |");
        MostrarAColor(marcoMedio, ConsoleColor.DarkCyan);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        MostrarAColor(marcoMedio, ConsoleColor.DarkCyan);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
        MostrarAColor(marcoSuperiorInferior, ConsoleColor.DarkCyan);
        CentrarTexto("Presiona Enter para ver el siguiente personaje...");
        CentrarTexto("Presiona cualquier otra tecla para omitir...");
    }

    private void ImprimirFila(string etiqueta, string valor)
    {
        // Ajusta el valor a un ancho fijo
        string valorAjustado = valor.Length > AnchoColumna ? valor.Substring(0, AnchoColumna - 3) + "..." : valor;
        CentrarTexto($"| {etiqueta,-12} | {valorAjustado,-30} |");
    }

    public void MostrarUnPersonaje(Personaje personaje)
    {
        Console.WriteLine("");
        MostrarAColor(" 「 ✦   Personaje elegido   ✦ 」 ", ConsoleColor.White);
        string marcoSuperiorInferior = new string('=', AnchoMarco);
        string marcoMedio = new string('-', AnchoMarco);
        MostrarAColor(marcoSuperiorInferior, ConsoleColor.DarkCyan);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        MostrarAColor(marcoMedio, ConsoleColor.DarkCyan);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
          MostrarAColor(marcoSuperiorInferior, ConsoleColor.DarkCyan);
        Thread.Sleep(3000);

    }

    public void MostrarHistorialGanadores(List<Ganador> listadoGanadores)
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarTexto("HISTORIAL DE GANADORES");
        if (listadoGanadores == null || listadoGanadores.Count == 0)
        {
            CentrarTexto("No hay personajes para mostrar.");
            return;
        }
        else
        {
            for (int i = 0; i < listadoGanadores.Count; i++)
            {
                CentrarTexto($"Ganador {i + 1}: {listadoGanadores[i].Nombre} con {listadoGanadores[i].Salud} de salud final");
            }
        }
        Thread.Sleep(5000);
    }


    private void CentrarASCII(string texto)
    {
       // Dividir el texto en líneas, manejando los diferentes saltos de línea posibles
    string[] lineas = texto.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    
    // Obtener el ancho de la pantalla de la consola
    int anchoPantalla = Console.WindowWidth;
    
    foreach (string linea in lineas)
    {
        // Calcular la cantidad de espacios en blanco necesarios para centrar la línea
        int espaciosEnBlanco = (anchoPantalla - linea.Length) / 2;
        
        // Asegurarse de que la cantidad de espacios en blanco no sea negativa
        espaciosEnBlanco = Math.Max(0, espaciosEnBlanco);
        
        // Imprimir la línea centrada
        Console.WriteLine(new string(' ', espaciosEnBlanco) + linea);
    }
    }

    public void Titulo()
    {
        string tituloJuego = @"
             ███████████ █████ ██████   █████   █████████   █████                      
            ░░███░░░░░░█░░███ ░░██████ ░░███   ███░░░░░███ ░░███                       
             ░███   █ ░  ░███  ░███░███ ░███  ░███    ░███  ░███                       
             ░███████    ░███  ░███░░███░███  ░███████████  ░███                       
             ░███░░░█    ░███  ░███ ░░██████  ░███░░░░░███  ░███                       
             ░███  ░     ░███  ░███  ░░█████  ░███    ░███  ░███      █                
             █████       █████ █████  ░░█████ █████   █████ ███████████                
            ░░░░░       ░░░░░ ░░░░░    ░░░░░ ░░░░░   ░░░░░ ░░░░░░░░░░░                 
                                                                                       
                                                                                       
                                                                                       
 ███████████ █████   █████████  █████   █████ ███████████ ██████████ ███████████       
░░███░░░░░░█░░███   ███░░░░░███░░███   ░░███ ░█░░░███░░░█░░███░░░░░█░░███░░░░░███      
 ░███   █ ░  ░███  ███     ░░░  ░███    ░███ ░   ░███  ░  ░███  █ ░  ░███    ░███      
 ░███████    ░███ ░███          ░███████████     ░███     ░██████    ░██████████       
 ░███░░░█    ░███ ░███    █████ ░███░░░░░███     ░███     ░███░░█    ░███░░░░░███      
 ░███  ░     ░███ ░░███  ░░███  ░███    ░███     ░███     ░███ ░   █ ░███    ░███      
 █████       █████ ░░█████████  █████   █████    █████    ██████████ █████   █████     
░░░░░       ░░░░░   ░░░░░░░░░  ░░░░░   ░░░░░    ░░░░░    ░░░░░░░░░░ ░░░░░   ░░░░░      


          
        ";
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(tituloJuego);
        Thread.Sleep(3000);
    }

    public void MensajeGanador()
    {

        string textoGanador = @"
   █████████    █████████    ██████   █████   █████████    █████████  ███████████ ██████████
 ███░░░░░███   ███░░░░░███ ░ ██████ ░░███   ███░░░░░███  ███░░░░░███░█░░░███░░░█░░███░░░░░█
 ███     ░░░  ░███    ░███  ░███░███ ░███  ░███    ░███ ░███    ░░░ ░   ░███  ░  ░███  █ ░ 
░███          ░███████████  ░███░░███░███  ░███████████ ░░█████████     ░███     ░██████   
░███    █████ ░███░░░░░███  ░███ ░░██████  ░███░░░░░███  ░░░░░░░░███    ░███     ░███░░█   
░░███  ░░███  ░███    ░███  ░███  ░░█████  ░███    ░███  ███    ░███    ░███     ░███ ░   █
 ░░█████████  █████   █████ █████  ░░█████ █████   █████░░█████████     █████     ██████████
  ░░░░░░░░░  ░░░░░   ░░░░░ ░░░░░    ░░░░░ ░░░░░   ░░░░░  ░░░░░░░░░     ░░░░░    ░░░░░░░░░░ 
                                                                                           
                                                                                            ";

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoGanador);
        Thread.Sleep(3000);
    }

    public void MensajePerdedor()
    {

        string textoPerdedor = @"
   
  ███████████  ██████████ ███████████   ██████████  █████  █████████  ███████████  ██████████
░░███░░░░░███░░███░░░░░█░░███░░░░░███ ░░███░░░░███ ░░███  ███░░░░░███░█░░░███░░░█░░███░░░░░ █
 ░███    ░███ ░███  █ ░  ░███    ░███  ░███   ░░███ ░███ ░███    ░░░ ░   ░███  ░  ░███  █ ░ 
 ░██████████  ░██████    ░██████████   ░███    ░███ ░███ ░░█████████     ░███     ░██████   
 ░███░░░░░░   ░███░░█    ░███░░░░░███  ░███    ░███ ░███  ░░░░░░░░███    ░███     ░███░░█   
 ░███         ░███ ░   █ ░███    ░███  ░███    ███  ░███  ███    ░███    ░███     ░███ ░    █
 █████        ██████████ █████   █████  ██████████  █████░░█████████     █████     ██████████
░░░░░        ░░░░░░░░░░ ░░░░░   ░░░░░ ░░░░░░░░░░   ░░░░░  ░░░░░░░░░     ░░░░░    ░░░░░░░░░░ 
                                                                                            
                                                                                            
                                                                                                                                                       
                                                                   ";
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoPerdedor);
        Thread.Sleep(2000);
    }

    public void MensajeGameOver()
    {
        string textoGameOver = @"
   █████████    █████████    ██████ ██████   ██████████
  ███░░░░░███  ███░░░░░███ ░░██████ ██████ ░░███░░░░░ █
 ███     ░░░  ░███    ░███  ░███░█████░███  ░███  █ ░ 
░███          ░███████████  ░███░░███ ░███  ░██████   
░███    █████ ░███░░░░░███  ░███ ░░░  ░███  ░███░░█   
░░███  ░░███  ░███    ░███  ░███      ░███  ░███ ░    █
 ░░█████████  █████   █████ █████     █████ ██████████
  ░░░░░░░░░  ░░░░░   ░░░░░ ░░░░░     ░░░░░ ░░░░░░░░░░ 
                                                      
                                                      
                                                      
    ███████    █████   █████ ██████████ ███████████   
  ███░░░░░███ ░░███   ░░███ ░░███░░░░░█░░███░░░░░███  
 ███     ░░███ ░███    ░███  ░███  █ ░  ░███    ░███  
░███      ░███ ░███    ░███  ░██████    ░██████████   
░███      ░███ ░░███   ███   ░███░░█    ░███░░░░░███  
░░███     ███   ░░░█████░    ░███ ░   █ ░███    ░███  
 ░░░███████░      ░░███      ██████████ █████   █████ 
   ░░░░░░░         ░░░      ░░░░░░░░░░ ░░░░░   ░░░░░  
                                                      
                                                      
                                                      
        ";
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoGameOver);
        Thread.Sleep(3000);
    }

    public void MensajeGanadorFinal()
    {
        string textoGandorFinal = @"
    █████████    █████████   ██████   █████   █████████    █████████  ███████████ ██████████
  ███░░░░░███  ███░░░░░███ ░░██████ ░░███   ███░░░░░███  ███░░░░░███░█░░░███░░░█░░███░░░░░█
 ███     ░░░  ░███    ░███  ░███░███ ░███  ░███    ░███ ░███    ░░░ ░   ░███  ░  ░███  █ ░ 
░███          ░███████████  ░███░░███░███  ░███████████ ░░█████████     ░███     ░██████   
░███    █████ ░███░░░░░███  ░███ ░░██████  ░███░░░░░███  ░░░░░░░░███    ░███     ░███░░█   
░░███  ░░███  ░███    ░███  ░███  ░░█████  ░███    ░███  ███    ░███    ░███     ░███ ░   █
 ░░█████████  █████   █████ █████  ░░█████ █████   █████░░█████████     █████    ██████████
  ░░░░░░░░░  ░░░░░   ░░░░░ ░░░░░    ░░░░░ ░░░░░   ░░░░░  ░░░░░░░░░     ░░░░░    ░░░░░░░░░░ 
                                                                                           
                                                                                           
                                                                                           
 █████         █████████      ███████████ █████ ██████   █████   █████████   █████         
░░███         ███░░░░░███    ░░███░░░░░░█░░███ ░░██████ ░░███   ███░░░░░███ ░░███          
 ░███        ░███    ░███     ░███   █ ░  ░███  ░███░███ ░███  ░███    ░███  ░███          
 ░███        ░███████████     ░███████    ░███  ░███░░███░███  ░███████████  ░███          
 ░███        ░███░░░░░███     ░███░░░█    ░███  ░███ ░░██████  ░███░░░░░███  ░███          
 ░███      █ ░███    ░███     ░███  ░     ░███  ░███  ░░█████  ░███    ░███  ░███      █   
 ███████████ █████   █████    █████       █████ █████  ░░█████ █████   █████ ███████████   
░░░░░░░░░░░ ░░░░░   ░░░░░    ░░░░░       ░░░░░ ░░░░░    ░░░░░ ░░░░░   ░░░░░ ░░░░░░░░░░░    
                                                                                           
                                                                                           
                                                                                           
        ";
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoGandorFinal);
    }

    public void MensajePrimerRound()
    {
        string textoPrimerRound = @"
  ███████████ █████ ███████████    █████████  ███████████             
░░███░░░░░░█░░███ ░░███░░░░░███  ███░░░░░███░█░░░███░░░ █             
 ░███   █ ░  ░███  ░███    ░███ ░███    ░░░ ░   ░███  ░              
 ░███████    ░███  ░██████████  ░░█████████     ░███                 
 ░███░░░█    ░███  ░███░░░░░███  ░░░░░░░░███    ░███                 
 ░███  ░     ░███  ░███    ░███  ███    ░███    ░███                 
 █████       █████ █████   █████░░█████████     █████                
░░░░░       ░░░░░ ░░░░░   ░░░░░  ░░░░░░░░░     ░░░░░                 
                                                                     
                                                                     
                                                                     
 ███████████      ███████    █████  █████ ██████   █████ ██████████  
░░███░░░░░███   ███░░░░░███ ░░███  ░░███ ░░██████ ░░███ ░░███░░░░███ 
 ░███    ░███  ███     ░░███ ░███   ░███  ░███░███ ░███  ░███   ░░███
 ░██████████  ░███      ░███ ░███   ░███  ░███░░███░███  ░███    ░███
 ░███░░░░░███ ░███      ░███ ░███   ░███  ░███ ░░██████  ░███    ░███
 ░███    ░███ ░░███     ███  ░███   ░███  ░███  ░░█████  ░███    ███ 
 █████   █████ ░░░███████░   ░░████████   █████  ░░█████ ██████████  
░░░░░   ░░░░░    ░░░░░░░      ░░░░░░░░   ░░░░░    ░░░░░ ░░░░░░░░░░   
                                                                     
                                                                                                                          
        ";
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoPrimerRound);
        Thread.Sleep(2000);
    }

    public void MensajeSegundoRound()
    {
        string textoSegundoRound = @"
   █████████  ██████████   █████████     ███████    ██████   █████ ██████████        
 ███░░░░░███░░███░░░░░█  ███░░░░░███  ███░░░░░███ ░░██████ ░░███ ░░███░░░░███       
░███    ░░░  ░███  █ ░  ███     ░░░  ███     ░░███ ░███░███ ░███  ░███   ░░███      
░░█████████  ░██████   ░███         ░███      ░███ ░███░░███░███  ░███    ░███      
 ░░░░░░░░███ ░███░░█   ░███         ░███      ░███ ░███ ░░██████  ░███    ░███      
 ███    ░███ ░███ ░   █░░███     ███░░███     ███  ░███  ░░█████  ░███    ███       
░░█████████  ██████████ ░░█████████  ░░░███████░   █████  ░░█████ ██████████        
 ░░░░░░░░░  ░░░░░░░░░░   ░░░░░░░░░     ░░░░░░░    ░░░░░    ░░░░░ ░░░░░░░░░░         
                                                                                    
                                                                                    
                                                                                    
 ███████████      ███████    █████  █████ ██████   █████ ██████████                 
░░███░░░░░███   ███░░░░░███ ░░███  ░░███ ░░██████ ░░███ ░░███░░░░███                
 ░███    ░███  ███     ░░███ ░███   ░███  ░███░███ ░███  ░███   ░░███               
 ░██████████  ░███      ░███ ░███   ░███  ░███░░███░███  ░███    ░███               
 ░███░░░░░███ ░███      ░███ ░███   ░███  ░███ ░░██████  ░███    ░███               
 ░███    ░███ ░░███     ███  ░███   ░███  ░███  ░░█████  ░███    ███                
 █████   █████ ░░░███████░   ░░████████   █████  ░░█████ ██████████                 
░░░░░   ░░░░░    ░░░░░░░      ░░░░░░░░   ░░░░░    ░░░░░ ░░░░░░░░░░                  
                                                                                    
                                                                           
        ";
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoSegundoRound);
        Thread.Sleep(2000);
    }

    public void MensajeFinalRound()
    {
        string textoFinalRound = @"
 ███████████ █████ ██████   █████  █████████   █████                
░░███░░░░░░█░░███ ░░██████ ░░███   ███░░░░░███ ░░███                 
 ░███   █ ░  ░███  ░███░███ ░███  ░███    ░███  ░███                 
 ░███████    ░███  ░███░░███░███  ░███████████  ░███                 
 ░███░░░█    ░███  ░███ ░░██████  ░███░░░░░███  ░███                 
 ░███  ░     ░███  ░███  ░░█████  ░███    ░███  ░███      █          
 █████       █████ █████  ░░█████ █████   █████ ███████████          
░░░░░       ░░░░░ ░░░░░    ░░░░░ ░░░░░   ░░░░░ ░░░░░░░░░░░           
                                                                     
                                                                     
                                                                     
 ███████████      ███████    █████  █████ ██████   █████ ██████████  
░░███░░░░░███   ███░░░░░███ ░░███  ░░███ ░░██████ ░░███ ░░███░░░░███ 
 ░███    ░███  ███     ░░███ ░███   ░███  ░███░███ ░███  ░███   ░░███
 ░██████████  ░███      ░███ ░███   ░███  ░███░░███░███  ░███    ░███
 ░███░░░░░███ ░███      ░███ ░███   ░███  ░███ ░░██████  ░███    ░███
 ░███    ░███ ░░███     ███  ░███   ░███  ░███  ░░█████  ░███    ███ 
 █████   █████ ░░░███████░   ░░████████   █████  ░░█████ ██████████  
░░░░░   ░░░░░    ░░░░░░░      ░░░░░░░░   ░░░░░    ░░░░░ ░░░░░░░░░░   
                                                                     
                                                                       
        ";
        Console.WriteLine("");
        Console.WriteLine("");
        CentrarASCII(textoFinalRound);
        Thread.Sleep(2000);
    }

}
