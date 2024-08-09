# Taller Lenguaje I - Proyecto Final 

# FINAL FIGHTER 

#### ¡Bienvenidos a Final Fighter! En este juego, tendrás la oportunidad de convertirte en un héroe. Preparate para la gloria. 

## Informacion sobre el juego 

Final Figther es un juego de rol por turnos donde los jugadores eligen un personaje único para enfrentarse a una serie de combates. En cada partida, tu personaje seleccionado se medirá contra tres oponentes elegidos aleatoriamente, uno tras otro. El objetivo es sobrevivir a cada batalla y avanzar a la siguiente ronda, pero si tu personaje es derrotado, el juego termina.

### Mecanica del juego

**Selección de Personaje**: Comienza el juego eligiendo uno de los personajes disponibles, cada uno con sus respectivos datos y caracteristicas. El programa se encargará de elegir a 3 personajes aleatorios para que sean tus enemigos en las batallas. 

**Combate por Turnos:**  Los enfrentamientos se desarrollan por turnos y de manera aleatoria, mostrando por pantalla el daño generado al openente por cada luchador.

**Progresión de Rondas**: Solo avanzarás a la siguiente ronda si derrotas al oponente actual. Si perdes, el juego termina. Cada vez que avances hacia la siguiente ronda recibirás una mejora en alguna de tus caracteristicas 

**Ataques Especiales:** Cada tres ataques que realices, tendrás la oportunidad de elegir un ataque especial. Este poderoso ataque aumenta tu capacidad de daño significativamente, pero conlleva un riesgo: en la siguiente ronda, tu defensa se verá reducida, lo que te hará más vulnerable a los ataques enemigos.

**Historial de Ganadores**: Si logras vencer a todos los oponentes y sobrevivir a las 3 rondas, tu nombre será registrado en el historial de ganadores, dejando una marca de tu éxito en el juego.

## Implementación y recursos

### Uso de API 
Este juego hace uso de la API: https://random-data-api.com/api/v2/users?size=1 la cual se encarga de obtener información sobre un usuario, como el nombre, dirección y otros detalles. En este caso, solo se hace uso del nombre obtenido, el cual será usado en la creación de los personajes. Para la conversión del JSON con los datos de la API a una clase en C# se usó la pagina: https://json2csharp.com/ 

### Música 
Para crear un ambiente de combate en el juego decidí agregar música de fondo y efectos de sonido. La idea principal era hacerlo a través de la clase SoundPlayer que se encuentra en el namespace System.Media, pero me encontré con dos problematicas: SoundPlayer solo está disponible para Windows (y esto genera multiples advertencias a la hora de compilar, lo que hacía que el programa se viera improlijo) y no permite la reproducción de dos sonidos al mismo tiempo. Sabiendo esto, opté por utilizar la biblioteca **NAudio**, que a pesar de estar diseñada unicamente para el ecosistema Windows, no produce advertencias en el codigo y cuenta con una gama mucho más amplia de funcionalidades para una manipulación avanzada de audio. 
Para descargar los sonidos utilizados se uso la página: https://ytconverter.app/es/youtube-to-wav/ 

**Creditos**

**Intro:** https://www.youtube.com/watch?v=LPdQ4T6lb2M

**Efecto al perder**: https://www.youtube.com/watch?v=qZIZ9ZqqgjY

**Efecto al ganar**: https://www.youtube.com/watch?v=rr5CMS2GtCY

**Efecto al empezar otra ronda**: https://www.youtube.com/watch?v=DO51tuTnzUI 

### Graficos
Para mejorar la estética del juego utilicé texto en ASCII que generé a mi gusto en la página: https://www.asciiart.eu/text-to-ascii-art, también usé pequeños símbolos de decoración sacados de https://www.coolsymbol.top/ 

### IA
La inteligencia artificial, especialmente ChatGPT y Geminis fueron herramientas de gran ayuda para el desarrollo de la parte visual del juego. Me dieron información útil sobre como cambiar de color la consola, mejorar el aspecto del menú, hacer cortas animaciones y centrar textos. También fueron cruciales para entender mejor el uso de la biblioteca NAudio y para la implementación de los métodos creados para reproducir sonido. 

##  Autora
**Nombre**: Camisay, Martina Yahel. 

**Carrera**: Programador Universitario.  