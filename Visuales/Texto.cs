namespace miProyecto;
public class Texto 
{
    Visuales visuales = new Visuales();
    public void MensajePresentacion()
    {
        string presentacion = "Bienvenidos a Final Fighter! En este juego, tendrás la oportunidad de convertirte en un héroe. Elige a tu personaje favorito y prepárate para enfrentarte a tres oponentes seleccionados aleatoriamente. La batalla continuará hasta que ganes todos los combates o hasta que caigas en la arena. Pero cuidado, cada ronda te ofrece la oportunidad de realizar un ataque especial que incrementará tu poder de ataque, aunque a costa de tu defensa en el próximo turno. Si sales victorioso, tu nombre será inmortalizado en la lista de ganadores históricos!" ;

        EscribirLento(presentacion);
        Thread.Sleep(2000); 
        visuales.CentrarTexto("Presione una tecla para continuar...");
        Console.ReadKey();
        
    }

    public void MensajeDespedida()
    {
        Console.Clear();
        visuales.CentrarTexto("Esperamos que te hayas divertido!");
        Thread.Sleep(1000); 
        visuales.CentrarTexto("Hasta Pronto");
    }

    public void EscribirLento(string mensaje)
    {
        foreach (char c in mensaje)
        {
            Console.Write(c);
            Thread.Sleep(20); // Pausa entre cada carácter
        }
        Console.WriteLine(); 
    }

}