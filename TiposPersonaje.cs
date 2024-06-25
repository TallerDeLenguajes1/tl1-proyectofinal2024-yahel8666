namespace miProyecto; 

public class TiposPersonajes
{
   List<string> ListaDeTipos = new List<string>
   {
        "Mago", "Elfo", "Enano", "Humano", "Raconeano", "Demonio", "Angel"
   };

    private readonly Random numeroRandom = new Random();
   public   string obtenerTipoAleatorio()
   {
    int i = numeroRandom.Next(ListaDeTipos.Count); 
    return ListaDeTipos[i]; 
   }

}