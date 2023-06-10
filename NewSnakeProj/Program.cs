using NewSnakeProj; // Importamos el namespace de la clase ventana.
using System.Drawing;

Ventana ventana;
Snake snake;
bool jugar = true;
void Iniciar()
{
    ventana = new Ventana("Snake", 65, 20, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen,
    new Point(5, 3), new Point(59, 18));
    ventana.DibujarMarco();
    snake = new Snake(new Point(8, 5), ConsoleColor.DarkRed, ConsoleColor.Red, ventana);
}

void Game()
{
    while (jugar)
    {
        snake.Mover();
        Thread.Sleep(100);
    }
}

Iniciar();
Game();
Console.ReadKey();
