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

        // Crearemos un nuevo método para que la serpiente tenga su cuerpo con sus partes.

        public void IniciarCuerpo(int numPartes)
        {
            int x = Head.X - 1; // Crearemos la cola de la serpiente.
            for (int i = 0; i < numPartes; i++) // Se cuenta la cantidad de partes del cuerpo de la serpiente.
            {
                Console.SetCursorPosition(x, Head.Y);
                Console.Write("▓");// Alt 178
                Body.Add(new Point(x, Head.Y));
                x--;
            }
        }

        // Crearemos un nuevo método que permita mover la serpiente.

        public void Mover()
        {
            Teclado(); // Lectura de direcciones de la serpiente desde teclado.
            Point posCabezaAnterior = Head; // Posicionaremos la cabeza inicial de la serpiente.
            MoverCabeza(); // Movimiento de la cabeza de la serpiente.
            MoverCuerpo(posCabezaAnterior);
        }

        // Crearemos un nuevo método que permita mover la cabeza de la serpiente.

        public void MoverCabeza()
        {
            Console.ForegroundColor = HeadColor; // Definimos el color de la cabeza.
            Console.SetCursorPosition(Head.X, Head.Y); // Ubicamos la posición donde se encuentra la cabeza de la serpiente.
            Console.WriteLine(" ");

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
            Console.WriteLine("█"); // ALT+219 (para evitar los rastros que dejó la serpiente en la consola).
        }

        // Crearemos un nuevo método para que la serpiente pueda mover su cuerpo.

        private void MoverCuerpo(Point posCabezaAnterior)
        {
            Console.ForegroundColor = BodyColor;
            Console.SetCursorPosition(posCabezaAnterior.X, posCabezaAnterior.Y);
            Console.WriteLine("▓"); // Alt 178 (para evitar los rastros que dejó la serpiente en la consola).
            Body.Insert(0, posCabezaAnterior);

            // Ubicaremos el cursor mediante lista de arreglos.

            Console.SetCursorPosition(Body[Body.Count - 1].X, Body[Body.Count - 1].Y);
            Console.WriteLine(" "); // Para evitar los rastros que dejó la serpiente en la consola.
            Body.Remove(Body[Body.Count - 1]);
        }

        // Crearemos un método que permita mover a la serpiente mediante lectura desde teclado.

        private void Teclado()
        {
            if (Console.KeyAvailable) // Si se presionó la tecla o la reconoce manualmente.
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                // Verificaremos para cada condición las direcciones de la serpiente mediante lecturas desde teclado.

                if (tecla.Key == ConsoleKey.RightArrow && (_direccion != Direccion.Izquierda)) // Si se presionó la tecla derecha pero que no se puede girar a la izquierda.
                    _direccion = Direccion.Derecha;
                if (tecla.Key == ConsoleKey.LeftArrow && (_direccion != Direccion.Derecha)) // Si se presionó la tecla izquierda pero que no se puede girar a la derecha.
                    _direccion = Direccion.Izquierda;
                if (tecla.Key == ConsoleKey.UpArrow && (_direccion != Direccion.Abajo)) // Si se presionó la tecla de arriba pero que no se puede girar desde abajo.
                    _direccion = Direccion.Arriba;
                if (tecla.Key == ConsoleKey.DownArrow && (_direccion != Direccion.Arriba)) // Si se presionó la tecla de abajo pero que no se puede girar desde arriba.
                    _direccion = Direccion.Abajo;
            }
        }
    }
}
