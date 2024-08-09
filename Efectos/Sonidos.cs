namespace miProyecto; 
using System.IO;
using NAudio.Wave;

public class Sonido
{
    private IWavePlayer waveOutDevice; //clase que reproduce 
    private AudioFileReader audioFileReader; //clase que lee el archivo de audio y lo convierte a formato

    public void ReproducirSonidoBucle(string ruta)
    {
        try
        {
            if (File.Exists(ruta))
            {
                waveOutDevice = new WaveOutEvent(); //crea el dispositivo de salida 
                audioFileReader = new AudioFileReader(ruta); //lee la ruta 

                waveOutDevice.Init(audioFileReader); //INIT sirve para inicializar el dispositivo de salida 
                waveOutDevice.Play(); //lo ejecuta 

                //cuando se detenga... 
                waveOutDevice.PlaybackStopped += (sender, args) =>
                {
                    try
                    {
                        //que lo reproduzca de nuevo 
                        audioFileReader.Position = 0; //pone la musica en 0:00
                        waveOutDevice.Init(audioFileReader);
                        waveOutDevice.Play();
                    }
                    catch
                    {
                        // Manejo silencioso de excepciones
                    }
                };
            }
        }
        catch
        {
            // Manejo silencioso de excepciones
        }
    }

    public void PararSonidoBucle()
{
    try
    {
        if (waveOutDevice != null)
        {
            
            waveOutDevice.Stop(); //para el audio
            waveOutDevice.Dispose(); //libera los recursos que se estén utilizando 
            waveOutDevice = null; // Asegura que no se vuelva a usar este dispositivo
        }

        if (audioFileReader != null)
        {
            // libera el lector de archivos de audio
            audioFileReader.Dispose();
            audioFileReader = null;
        }
    }
    catch (Exception ex)
    {
        // Captura cualquier excepción y opcionalmente puedes hacer logging
        Console.WriteLine("Error al detener el sonido: " + ex.Message);
    }
}

    // reproducir sin bucle
    public void ReproducirSonido(string rutaSonido)
    {
        try
        {
            if (File.Exists(rutaSonido))
            {
                //crea un hilo para la reproducción, la reproducción de audio se ejecuta en un hilo separado del hilo principal de la aplicación. (para que no pare la ejecución del juego)
                Thread sonidoThread = new Thread(() =>
                {
                    try
                    {
                        using (var outputDevice = new WaveOutEvent())
                        using (var soundPlayer = new AudioFileReader(rutaSonido))
                        {
                            outputDevice.Init(soundPlayer);
                            outputDevice.Play();

                            // Esperar hasta que termine la reproducción
                            while (outputDevice.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(100); 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al reproducir el sonido en el hilo: " + ex.Message);
                    }
                });

                sonidoThread.IsBackground = true; // Permite que el hilo termine si el proceso principal termina
                sonidoThread.Start();
            }
            else
            {
                Console.WriteLine("El archivo de sonido no existe: " + rutaSonido);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al configurar la reproducción del sonido: " + ex.Message);
        }
    }
}