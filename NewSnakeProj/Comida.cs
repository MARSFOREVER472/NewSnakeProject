using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewSnakeProj
{
    // Crearemos nuestra clase para la comida.
    internal class Comida
    {
        // Definiremos las variables para la comida de la serpiente.

        public Point Posicion { get; set; } // Posicion de la comida.
        public ConsoleColor Color { get; set; } // Color para la comida.
        public Ventana Window { get; set; } // Ventana de la consola para la comida.

        // Crearemos un constructor para la clase Comida sin contar con la posición en donde se encuentra.

        public Comida(ConsoleColor color, Ventana ventana)
        {
            Color = color; // Color
            Window = ventana; // Ventana de la consola.
        }

        // Crearemos un nuevo método que permita visualizar la comida dependiendo de la posición en donde se encuentra.

        private void Dibujar()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.Write("█"); // ALT 219
        }

        // Crearemos un nuevo método que permita generar una comida para la serpiente y llamaremos al método anterior para su posterior ejecución.

        public bool GenerarComida(Snake snake)
        {
            int longitudSnake = snake.Body.Count + 1; // Incrementa la longitud del cuerpo de la serpiente mediante una lista de arreglos.

            if ((Window.Area - longitudSnake) <= 0) // Verifica si es que no hay espacio suficiente para seguir creciendo al comer.
                return false;

            Random random = new Random(); // Crearemos una variable de tipo Random.
            int x = random.Next(Window.LimiteSuperior.X + 1, Window.LimiteInferior.X); // Para la coordenada en X.
            int y = random.Next(Window.LimiteSuperior.Y + 1, Window.LimiteInferior.Y); // Para la coordenada en Y.
            Posicion = new Point(x, y); // Ubicaremos la posición dependiendo de la coordenada en el punto x,y.

            foreach (Point item in snake.Body) // Con este ciclo recorremos todo el cuerpo de la serpiente.
            {
                if((x == item.X && y == item.Y) ||
                    (x == snake.Head.X && y == snake.Head.Y))
                {
                    if (GenerarComida(snake))
                        return true; // Si se generó la comida de la serpiente.
                }
            }
            Dibujar(); // Llamado del método anterior.
            return true; // Retorna verdadero si es que se cumple con el ciclo anterior.
        }

    }
}
