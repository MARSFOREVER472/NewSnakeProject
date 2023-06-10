using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewSnakeProj
{
    internal class Snake // Clase Serpiente
    {
        enum Direccion // Movemos la serpiente en distintas direcciones.
        {
            Arriba, Abajo, Derecha, Izquierda
        }
            
        public bool Vivo { get; set; } // vida de la serpiente.
        public ConsoleColor HeadColor { get; set; } // color de cabeza de la serpiente.
        public ConsoleColor BodyColor { get; set; } // color de cuerpo de la serpiente.
        public Ventana Window { get; set; } // Ventana de la consola.
        public List<Point> Body { get; set; } // cuerpo de la serpiente.
        public Point Head { get; set; } // Cabeza de la serpiente.
        private Direccion _direccion; // Dirección de la serpiente.

        // Crearemos un constructor con sus respectivos parámetros para la clase Snake

        public Snake(Point posicion, ConsoleColor colorCabeza, ConsoleColor colorCuerpo,
            Ventana ventana)
        {
            HeadColor = colorCabeza; // Color de cabeza.
            BodyColor = colorCuerpo; // Color de cuerpo.
            Window = ventana; // Ventana de la consola.
            Head = posicion; // Posición de la cabeza.
            Body = new List<Point>(); // Cuerpo definido según crecimiento de la serpiente.

            _direccion = Direccion.Derecha; // Se mueve hacia la derecha.
        }

        // Crearemos un nuevo método que permita mover la serpiente.

        public void Mover()
        {
            MoverCabeza();
        }

        // Crearemos un nuevo método que permita mover la cabeza de la serpiente.

        public void MoverCabeza()
        {
            Console.ForegroundColor = HeadColor; // Definimos el color de la cabeza.
            Console.SetCursorPosition(Head.X, Head.Y); // Ubicamos la posición donde se encuentra la cabeza de la serpiente.
            Console.Write(" ");

            // Definiremos las posiciones y un movimiento utilizando el algoritmo de switch con un case.

            switch (_direccion)
            {
                case Direccion.Derecha: // Hacia la derecha.
                    Head = new Point(Head.X + 1, Head.Y);
                    break;
                case Direccion.Izquierda: // Hacia la izquierda.
                    Head = new Point(Head.X - 1, Head.Y);
                    break;
                case Direccion.Abajo: // Hacia abajo.
                    Head = new Point(Head.X, Head.Y + 1);
                    break;
                case Direccion.Arriba: // Hacia arriba.
                    Head = new Point(Head.X, Head.Y - 1);
                    break;
            }

            // Definidos ya las posiciones moveremos la cabeza de la serpiente.

            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write("█"); // ALT+219
        }
    }
}
