using NewSnakeProj; // Importamos el namespace de la clase ventana.

Ventana ventana = new Ventana("Snake", 65, 20, ConsoleColor.DarkYellow, ConsoleColor.DarkGreen);

Console.SetCursorPosition(5, 5); // Ubicación del cursor por punto en la consola.
Console.Write("HOY NOS ENFOCAREMOS EN LA CREACIÓN DEL VIDEOJUEGO");

Console.SetCursorPosition(5, 8); // Ubicación del cursor por punto en la consola.
Console.Write("PARA CREAR UN MARCO DE JUEGO");

Console.ReadKey();
