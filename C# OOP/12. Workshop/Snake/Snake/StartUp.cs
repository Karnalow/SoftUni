using Snake.Core;
using Snake.GameObjects;
using Snake.Utilities;
using System;
using System.Collections.Generic;

namespace Snake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(100, 20);

            GameObjects.Snake snake = new GameObjects.Snake(wall);

            Engine engine = new Engine(snake);
            engine.Run();
        }
    }
}
