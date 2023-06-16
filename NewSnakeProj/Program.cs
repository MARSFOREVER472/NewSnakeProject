using NewSnakeProj; // Importamos el namespace de la clase ventana.
using System.Drawing; // Importamos la librería para la consola al dibujarla.

Ventana ventana; // Variable ventana.
Snake snake; // Variable para la serpiente.
Comida comida; // Variable para la comida.
bool ejecutar = true; // Ejecución si responde o no.
bool jugar = false; // Se realizaron todos los ajustes correctamente a la interfaz del juego.

// Método para inicializar el juego.
void Iniciar()
{
    ventana = new Ventana("Snake", 65, 20, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen,
    new Point(5, 3), new Point(59, 18)); // Constructor para dibujar el marco en la consola.
    ventana.DibujarMarco();
    comida = new Comida(ConsoleColor.DarkGray, ventana); // Creación de la comida.
    snake = new Snake(new Point(8, 5), ConsoleColor.DarkRed, ConsoleColor.Red, ventana, comida); // Creación de la serpiente.
    
}

// Método para jugar.
void Game()
{
    while (ejecutar) // Para ejecutar el juego completo.
    {
        ventana.Maingame();
        ventana.Teclado(ref ejecutar, ref jugar, snake);
        while (jugar) // Mientras se ejecuta el juego.
        {
            snake.Informacion(0, 34); // Información de la serpiente.
            snake.Mover(); // Movimiento de la serpiente.

            if (!snake.Vivo) // Verificaremos si la serpiente está muerta.
            {
                jugar = false; // No va a seguir jugando.
                snake.Puntaje = 0; // Se inicializa el puntaje en 0.
            }

            Thread.Sleep(100); // Duerme el programa durante 50 milisegundos mediante hilos de ejecución.
        }
        Thread.Sleep(100); // Para que la serpiente del menú no se mueva muy rápido.
    }

}

Iniciar(); // Llamado del método al iniciar el programa.
Game(); // Llamado del método al juego.

