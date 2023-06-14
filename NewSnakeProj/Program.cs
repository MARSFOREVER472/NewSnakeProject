using NewSnakeProj; // Importamos el namespace de la clase ventana.
using System.Drawing;

Ventana ventana; // Variable ventana.
Snake snake; // Variable para la serpiente.
Comida comida; // Variable para la comida.
bool jugar = true; // Jugada disponible para su ejecución.

// Método para inicializar el juego.
void Iniciar()
{
    ventana = new Ventana("Snake", 65, 20, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen,
    new Point(5, 3), new Point(59, 18)); // Constructor para dibujar el marco en la consola.
    ventana.DibujarMarco();
    comida = new Comida(ConsoleColor.DarkGray, ventana); // Creación de la comida.
    snake = new Snake(new Point(8, 5), ConsoleColor.DarkRed, ConsoleColor.Red, ventana, comida); // Creación de la serpiente.
    snake.IniciarCuerpo(2);

    comida.GenerarComida(); // Con ese método siempre se debe dejar público.
}

// Método para jugar.
void Game()
{
    while (jugar) // Mientras se ejecuta el juego.
    {
        snake.Mover(); // Movimiento de la serpiente.
        Thread.Sleep(100); // Duerme el programa durante 100 milisegundos mediante hilos de ejecución.
    }
}

Iniciar(); // Llamado del método al iniciar el programa.
Game(); // Llamado del método al juego.
Console.ReadKey(); // Se muestra la lectura de la consola al terminar su ejecución.
