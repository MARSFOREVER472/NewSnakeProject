using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // Para dibujar en la consola.

namespace NewSnakeProj
{
    internal class Ventana
    {
        public string Title { get; set; } // Titulo del juego.
        public int Width { get; set; } // Ancho de la ventana.
        public int Height { get; set; } // Altura de la ventana.
        public ConsoleColor BackgroundColor { get; set; } // Color de fondo del juego.
        public ConsoleColor TextColor { get; set; } // Color de texto del juego.
        public Point LimiteSuperior { get; set; } // Límite superior del marco de la consola.
        public Point LimiteInferior { get; set; } // Límite inferior del marco de la consola.
        public int Area { get; set; } // Área de la consola.

        // Crearemos un constructor para la clase Ventana.

        public Ventana(string titulo, int ancho, int altura,
            ConsoleColor colorFondo, ConsoleColor colorLetra,
            Point limiteSuperior, Point limiteInferior)
        {
            Title = titulo; // Titulo
            Width = ancho; // Ancho
            Height = altura; // Altura
            BackgroundColor = colorFondo; // Color de fondo
            TextColor = colorLetra; // Color de texto
            LimiteSuperior = limiteSuperior; // Límite superior
            LimiteInferior = limiteInferior; // Límite inferior
            Area = ((LimiteInferior.X - LimiteSuperior.X) - 1) * ((LimiteInferior.Y - LimiteSuperior.Y) - 1); // Se calcula multiplicando los límites superior e inferior del marco del juego.
            Init(); // Llama al constructor a todas las variables del juego.
        }

        // Crearemos un nuevo método para configuración inicial de la ventana de consola.

        public void Init()
        {
            Console.SetWindowSize(Width, Height); // Dimensiones de la ventana de consola.
            Console.Title = Title; // Para el titulo de la consola.
            Console.CursorVisible = false; // En el caso de que el cursor no se visualice en la consola.
            Console.BackgroundColor = BackgroundColor; // Para personalizar el color de fondo de la consola.
            Console.Clear(); // Limpia toda la consola al ejecutarse.
        }

        // Crearemos un nuevo método para dibujar el marco en la consola.

        public void DibujarMarco()
        {
            Console.ForegroundColor = TextColor; // Para el color de letra.

            for (int i = LimiteSuperior.X; i < LimiteInferior.X; i++) // Para el ancho del marco.
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y); // Límite Superior
                Console.Write("═");
                Console.SetCursorPosition(i, LimiteInferior.Y); // Límite Inferior
                Console.Write("═");
            }

            for (int i = LimiteSuperior.Y; i < LimiteInferior.Y; i++) // Para la altura del marco.
            {
                Console.SetCursorPosition(LimiteSuperior.X, i); // Límite Izquierdo del marco.
                Console.Write("║");
                Console.SetCursorPosition(LimiteInferior.X, i); // Límite Derecho del marco.
                Console.Write("║");
            }

            // Procedemos a dibujar las esquinas del marco

            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y); // Parte superior izquierdo del marco.
            Console.Write("╔"); // ALT + 201
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y); // Parte inferior izquierdo del marco.
            Console.Write("╚"); // ALT + 200
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y); // Parte superior derecho del marco.
            Console.Write("╗"); // ALT + 187
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y); // Parte inferior derecho del marco.
            Console.Write("╝"); // ALT + 188
        }
    }
}
