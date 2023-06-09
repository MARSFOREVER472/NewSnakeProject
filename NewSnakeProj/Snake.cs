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
        public bool Vivo { get; set; } // vida de la serpiente.
        public ConsoleColor HeadColor { get; set; } // color de cabeza de la serpiente.
        public ConsoleColor BodyColor { get; set; } // color de cuerpo de la serpiente.
        public Ventana Window { get; set; } // Ventana de la consola.
        public List<Point> Body { get; set; } // cuerpo de la serpiente.
        public Point Head { get; set; } // Cabeza de la serpiente.

        // Crearemos un constructor con sus respectivos parámetros para la clase Snake

        public Snake(Point posicion, ConsoleColor colorCabeza, ConsoleColor colorCuerpo,
            Ventana ventana)
        {
            HeadColor = colorCabeza; // Color de cabeza.
            BodyColor = colorCuerpo; // Color de cuerpo.
            Window = ventana; // Ventana de la consola.
            Head = posicion; // Posición de la cabeza.
            Body = new List<Point>(); // Cuerpo definido según crecimiento de la serpiente.
        }
    }
}
