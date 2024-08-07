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

        CentrarTexto(marcoSuperiorInferior);
        CentrarTexto($"| {"Personaje",-12} | {numero,-AnchoColumna} |");
        CentrarTexto(marcoMedio);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        CentrarTexto(marcoMedio);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
        CentrarTexto(marcoSuperiorInferior);
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
        CentrarTexto("Personaje elegido: ");
        string marcoSuperiorInferior = new string('=', AnchoMarco);
        string marcoMedio = new string('-', AnchoMarco);
        CentrarTexto(marcoSuperiorInferior);
        CentrarTexto(marcoMedio);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        CentrarTexto(marcoMedio);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
        CentrarTexto(marcoSuperiorInferior);
        Thread.Sleep(3000);

    }

    public void MostrarHistorialGanadores(List<Ganador> listadoGanadores)
    {
        Console.Clear();
        string lineaDecorativa = new string('=', Console.WindowWidth - 20);

        CentrarTexto(lineaDecorativa);
        CentrarTexto("HISTORIAL DE GANADORES");
        CentrarTexto(lineaDecorativa);
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

        CentrarASCII(textoGanador);
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
        CentrarASCII(textoPerdedor);
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

        CentrarASCII(textoGameOver);
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

        CentrarASCII(textoPrimerRound);
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

        CentrarASCII(textoSegundoRound);
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

        CentrarASCII(textoFinalRound);
    }

}
