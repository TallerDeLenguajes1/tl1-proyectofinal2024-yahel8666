using System;
using System.Collections.Generic;
namespace miProyecto;
public class Visuales
{
    private const int AnchoColumna = 30;
    private const int AnchoMarco = AnchoColumna + 18; // para márgenes

    public static void CentrarTexto(string texto)
    {
        int anchoPantalla = Console.WindowWidth;
        int espaciosPrevios = (anchoPantalla - texto.Length) / 2;
        Console.WriteLine(new string(' ', Math.Max(0, espaciosPrevios)) + texto);
    }
   
    public void MostrarListaDePersonajes(List<Personaje> personajes, int cantidad)
    {
        if (personajes == null || personajes.Count == 0)
        {
            Visuales.CentrarTexto("No hay personajes para mostrar.");
            return;
        }
        int indiceActual = 0;
        ConsoleKeyInfo teclaPresionada;
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

        Visuales.CentrarTexto(marcoSuperiorInferior);
        Visuales.CentrarTexto($"| {"Personaje",-12} | {numero,-AnchoColumna} |");
        Visuales.CentrarTexto(marcoMedio);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        Visuales.CentrarTexto(marcoMedio);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
        Visuales.CentrarTexto(marcoSuperiorInferior);
        Visuales.CentrarTexto("Presiona Enter para ver el siguiente personaje...");
        Visuales.CentrarTexto("Presiona cualquier otra tecla para omitir...");
    }

    public static void ImprimirFila(string etiqueta, string valor)
    {
        // Ajusta el valor a un ancho fijo
        string valorAjustado = valor.Length > AnchoColumna ? valor.Substring(0, AnchoColumna - 3) + "..." : valor;
        Visuales.CentrarTexto($"| {etiqueta,-12} | {valorAjustado,-30} |");
    }

    public void MostrarUnPersonaje(Personaje personaje)
    {
        string marcoSuperiorInferior = new string('=', AnchoMarco);
        string marcoMedio = new string('-', AnchoMarco);

        Visuales.CentrarTexto(marcoSuperiorInferior);
        Visuales.CentrarTexto(marcoMedio);
        ImprimirFila("Nombre", personaje.Datos.Nombre);
        ImprimirFila("Tipo", personaje.Datos.Tipo);
        ImprimirFila("Fecha Nac.", personaje.Datos.FechaNac.ToShortDateString());
        ImprimirFila("Edad", personaje.Datos.Edad.ToString());
        Visuales.CentrarTexto(marcoMedio);
        ImprimirFila("Velocidad", personaje.Caracteristicas.Velocidad.ToString());
        ImprimirFila("Destreza", personaje.Caracteristicas.Destreza.ToString());
        ImprimirFila("Fuerza", personaje.Caracteristicas.Fuerza.ToString());
        ImprimirFila("Armadura", personaje.Caracteristicas.Armadura.ToString());
        ImprimirFila("Nivel", personaje.Caracteristicas.Nivel.ToString());
        ImprimirFila("Salud", personaje.Caracteristicas.Salud.ToString());
        Visuales.CentrarTexto(marcoSuperiorInferior);
    }
}