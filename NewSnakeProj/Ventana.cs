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
        public Snake SnakeMain { get; set; } // Serpiente adicional para el menú.

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
            SnakeMain = new Snake(new Point(LimiteInferior.X / 2, LimiteInferior.Y - 3),
                ConsoleColor.Magenta, ConsoleColor.White, this, null); // Nueva serpiente para el menú.
            SnakeMain.IniciarCuerpo(4); // Iniciamos su cuerpo con 4 partes.
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

        // Crearemos un nuevo método que visualice la ventana para el menú del juego.

        public void Maingame()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue; // El color de letra es azul oscuro.
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 12,
                LimiteSuperior.Y + (LimiteInferior.Y / 2) - 4); // Ubicaremos el cursor en el centro del marco del menú principal.
            Console.Write("S N A K E   G A M E"); // Título del juego.
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 8,
                LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2); // Para ir a jugar.
            Console.Write("Enter - JUGAR"); // Botón ENTER para jugar.
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 8,
                LimiteSuperior.Y + (LimiteInferior.Y / 2) - 1); // Para salir del juego.
            Console.Write("ESC - SALIR"); // Botón Esc para salir.

            SnakeMain.MoverMenu(); // Se apreciará la nueva serpiente al menú.
        }

        // Crearemos un nuevo método que permita al menú leer botones desde teclado.

        public void Teclado(ref bool ejecutar, ref bool jugar, Snake snake)
        {
            if (Console.KeyAvailable) // Si se logró presionar una tecla mediante lectura.
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Enter) // Si se presionó la tecla ENTER.
                {
                    jugar = true; // Para ir a jugar.
                    Console.Clear();
                    DibujarMarco();
                    snake.Init();
                }

                if (tecla.Key == ConsoleKey.Escape) // Si se presionó la tecla ESC.
                {
                    ejecutar = false; // Salimos del juego.
                }
                    
            }
        }

        // Crearemos un nuevo método para terminar la partida al perder el juego.

        public void GameOver(string text)
        {
            Console.Clear(); // Limpiaremos toda la consola para proseguir la ejecución.
            DibujarMarco(); // Dibujaremos el marco del juego.
            Console.ForegroundColor = ConsoleColor.DarkBlue;// Agregaremos un color para la alerta del juego.
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 10,
                LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2); // Ubicaremos el cursor en el centro del marco del juego.
            Console.Write(text); // Pasaremos el texto automáticamente.
            Thread.Sleep(3000); // Dormiremos el programa durante 3000 milisegundos.
            Console.Clear(); // Limpiamos nuevamente.
            DibujarMarco(); // Dibujamos nuevamente el marco del juego.
        }
    }
}