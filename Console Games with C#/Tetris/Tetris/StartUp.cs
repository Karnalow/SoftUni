using System;
using System.Threading;

namespace Tetris
{
    class StartUp
    {
        // Settings
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + InfoCols + 2;

        // State
        static int Score = 0;

        static void Main(string[] args)
        {
            Console.Title = "Tetris";
            Console.CursorVisible = false;
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;

            DrawBorder();
            DrawInfo();

            while(true)
            {
                Score++;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                }

                DrawBorder();
                DrawInfo();

                Thread.Sleep(40);
            }
        }

        static void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);

            string line = "╔";
            line += new string('═', TetrisCols);
            line += "╦";
            line += new string('═', InfoCols);
            line += "╗";

            Console.Write(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";

                middleLine += new string(' ', TetrisCols);
                middleLine += "║";
                middleLine += new string(' ', InfoCols);
                middleLine += "║";

                Console.Write(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";

            Console.Write(endLine);
        }

        static void DrawInfo()
        {
            Write("Score:", 1, 3 + TetrisCols);
            Write(Score.ToString(), 2, 3 + TetrisCols);
        }

        static void Write(string text, int row, int col, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
