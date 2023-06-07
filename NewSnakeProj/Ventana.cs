using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSnakeProj
{
    internal class Ventana
    {
        public string Title { get; set; } // Titulo del juego
        public int Width { get; set; } // Ancho de la ventana
        public int Height { get; set; } // Altura de la ventana
        public ConsoleColor BackgroundColor { get; set; } // Color de fondo del juego
        public ConsoleColor TextColor { get; set; } // Color de texto del juego

        // Crearemos un constructor para la clase Ventana.

        public Ventana(string titulo, int ancho, int altura,
            ConsoleColor colorFondo, ConsoleColor colorLetra)
        {
            Title = titulo; // Titulo
            Width = ancho; // Ancho
            Height = altura; // Altura
            BackgroundColor = colorFondo; // Color de fondo
            TextColor = colorLetra; // Color de texto
            Init(); // Llama al constructor a todas las variables del juego.
        }

        // Crearemos un nuevo método para configuración inicial de la ventana de consola.

        public void Init()
        {
            Console.SetWindowSize(Width, Height); // Dimensiones de la ventana de consola.
            Console.Title = Title; // Para el titulo de la consola.
            Console.CursorVisible = false; // En el caso de que el cursor no sea visible en la consola.
            Console.BackgroundColor = BackgroundColor; // Para personalizar el color de fondo de la consola.
            Console.Clear(); // Limpia toda la consola al ejecutarse.
        }
    }
}
