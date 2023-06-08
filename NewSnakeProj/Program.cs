using NewSnakeProj; // Importamos el namespace de la clase ventana.
using System.Drawing;

Ventana ventana = new Ventana("Snake", 65, 20, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen,
    new Point(5, 3), new Point(59, 18));

ventana.DibujarMarco();

Console.ReadKey();
