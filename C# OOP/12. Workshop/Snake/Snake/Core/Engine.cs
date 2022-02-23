using Snake.Enums;
using Snake.GameObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake.Core
{
    public class Engine
    {
        private Direction direction;
        private Dictionary<Direction, Point> pointDirections;
        private GameObjects.Snake snake;

        public Engine(GameObjects.Snake snake)
        {
            this.snake = snake;

            this.direction = Direction.Right;

            this.pointDirections = new Dictionary<Direction, Point>()
            {
                { Direction.Left, new Point(-1, 0)},
                { Direction.Right, new Point(1, 0)},
                { Direction.Up, new Point(0, -1)},
                { Direction.Down, new Point(0, 1)}
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetDirection();
                }

                bool tryMove = this.snake.TryMove(this.pointDirections[this.direction]);

                if (!tryMove)
                {
                    Console.WriteLine("Game over!");

                    Console.SetCursorPosition(105, 0);
                    Console.Write("Would you like to continue? y/n");

                    string input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Clear();
                        StartUp.Main();
                    }
                    else if (input == "n")
                    {
                        Environment.Exit(0);
                    }
                }

;
                Thread.Sleep(200);
            }
        }

        private void GetDirection()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
