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
        public Comida Food { get; set; } // Comida de la serpiente.
        public int Puntaje { get; set; } // Puntaje del juego.
        public int MaximoPuntaje { get; set; } // Puntaje récord.
        private Direccion _direccion; // Dirección de la serpiente.
        private bool _eating; // Al momento de comer, éste dependerá lo que hace si se colisiona con la comida.

        // Crearemos un constructor con sus respectivos parámetros para la clase Snake

        public Snake(Point posicion, ConsoleColor colorCabeza, ConsoleColor colorCuerpo,
            Ventana ventana, Comida comida)
        {
            HeadColor = colorCabeza; // Color de cabeza.
            BodyColor = colorCuerpo; // Color de cuerpo.
            Window = ventana; // Ventana de la consola.
            Head = posicion; // Posición de la cabeza.
            Body = new List<Point>(); // Cuerpo definido según crecimiento de la serpiente.
            Food = comida; // Comida.
            Puntaje = 0; // Puntaje del juego.
            MaximoPuntaje = 0; // Puntaje Máximo del juego.
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
            MoverCuerpo(posCabezaAnterior); // Movimiento del cuerpo de la serpiente.
            ColisionesComida(); // Colisión hacia la comida de la serpiente.
            if (ColisionesCuerpo()) // Para las colisiones con el cuerpo se debe verificar con una condición mediante un bool hacia el mismo método.
            {
                Muerte(); // La serpiente murió.
                Environment.Exit(0); // Finaliza la ejecución con éxito sin errores.
            }
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

            // Llamaremos al método para que la serpiente pueda chocar con alguna parte dentro del marco.

            ColisionesMarco();

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

            // Ya no podrá hacer nada y se moverá el cuerpo al momento de comer.

            if (_eating)
            {
                _eating = false;
                return;
            }

            // Ubicaremos el cursor mediante lista de arreglos.

            Console.SetCursorPosition(Body[Body.Count - 1].X, Body[Body.Count - 1].Y);
            Console.WriteLine(" "); // Para evitar los rastros que dejó la serpiente en la consola.
            Body.Remove(Body[Body.Count - 1]);
        }

        // Crearemos un método que permita que la serpiente colisione con la comida mediante acciones especiales.

        private void ColisionesComida()
        {
            if (Head == Food.Posicion) // Se posiciona automáticamente en cualquier parte donde se encuentra la comida.
            {
                if (!Food.GenerarComida(this)) // Si es que no habrá suficiente espacio para generar comida.
                {
                    Vivo = false;
                    Environment.Exit(0);
                }
                _eating = true; // Va creciendo al comer.
                Puntaje++; // Al comer incrementa el valor de su puntaje.

                if (Puntaje > MaximoPuntaje) // Si el puntaje máximo es mayor que su puntaje actual.
                    MaximoPuntaje = Puntaje; // Esto se reemplazará por un puntaje récord si es que esta condición se cumple.
            }
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

        // Crearemos un nuevo método para evitar que la serpiente no sobrepase por el marco del juego..

        private void ColisionesMarco()
        {
            if (Head.X <= Window.LimiteSuperior.X) // Para que la serpiente choque hacia el lado izquierdo del marco según sus coordenadas en x.
                Head = new Point(Window.LimiteInferior.X - 1, Head.Y); // Moveremos la cabeza de la serpiente hacia el lado derecho.
            if (Head.X >= Window.LimiteInferior.X) // Para que la serpiente choque hacia el lado derecho del marco según sus coordenadas en x.
                Head = new Point(Window.LimiteSuperior.X + 1, Head.Y); // Moveremos la cabeza de la serpiente hacia el lado izquierdo.
            if (Head.Y <= Window.LimiteSuperior.Y) // Para que la serpiente choque hacia la parte del marco superior según sus coordenadas en y.
                Head = new Point(Head.X, Window.LimiteInferior.Y - 1); // Moveremos la cabeza de la serpiente hacia la parte inferior.
            if (Head.Y >= Window.LimiteInferior.Y) // Para que la serpiente choque hacia la parte del marco inferior según sus coordenadas en y.
                Head = new Point(Head.X, Window.LimiteSuperior.Y + 1); // Moveremos la cabeza de la serpiente hacia la parte superior.
        }

        // Crearemos un método privado que permita realizar acciones al colisionar su cuerpo.

        private bool ColisionesCuerpo()
        {
            foreach (Point item in Body) // Partes del cuerpo mediante foreach.
            {
                if (Head == item) // Si la cabeza es igual a la posición de su cuerpo.
                {
                    Vivo = false; // La serpiente ha muerto.
                    return true; // Si la condición if se cumple.
                }
            }
            return false; // Si es que el ciclo foreach no se cumple.
        }

        // Crearemos un método para que la serpiente se muera fácilmente.

        public void Muerte()
        {
            Console.ForegroundColor = BodyColor;
            foreach (Point item in Body)
            {
                if (item == Head)
                    continue;
                Console.SetCursorPosition(item.X, item.Y); // Ubicaremos la posición de su cuerpo cuando la serpiente se muera.
                Console.Write("░"); // ALT 176
                Thread.Sleep(120); // Dormiremos el programa mediante hilos de ejecución con un tiempo determinado.
            }
        }

        // Crearemos un método que muestre toda la información del juego.
        public void Informacion(int distanciaX1, int distanciaX2)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; // El color de letra es Rojo Oscuro.
            Console.SetCursorPosition(Window.LimiteSuperior.X + distanciaX1, Window.LimiteSuperior.Y - 1); // Información del puntaje.
            Console.Write("Puntaje: " + Puntaje + "  ");
            Console.SetCursorPosition(Window.LimiteSuperior.X + distanciaX2, Window.LimiteSuperior.Y - 1); // Información del puntaje máximo.
            Console.Write("Puntaje Máximo: " + MaximoPuntaje + "  ");


        }
    }
}
