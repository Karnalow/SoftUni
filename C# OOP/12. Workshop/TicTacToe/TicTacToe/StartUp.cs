using System;
using TicTacToe.Players;

namespace TicTacToe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe Game by Karnalov";

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==== TicTacToe 1.0 ====");
                Console.WriteLine("1. Player vs Player");
                Console.WriteLine("2. Player vs Random");
                Console.WriteLine("3. Random vs Player");
                Console.WriteLine("4. Player vs AI");
                Console.WriteLine("5. AI vs Player");
                Console.WriteLine("6. Simulate Random vs Random");
                Console.WriteLine("7. Simulate AI vs Random");
                Console.WriteLine("8. Simulate Random vs AI");
                Console.WriteLine("0. Exit");

                Console.WriteLine();

                while (true)
                {
                    Console.Write("Please enter number [0-8]");

                    string line = Console.ReadLine();

                    if (line == "1")
                    {
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());

                        break;
                    }
                    else if (line == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());

                        break;
                    }
                    else if (line == "3")
                    {
                        PlayGame(new RandomPlayer(), new ConsolePlayer());

                        break;
                    }
                    else if (line == "4")
                    {
                        PlayGame(new ConsolePlayer(), new AiPlayer());

                        break;
                    }
                    else if (line == "5")
                    {
                        PlayGame(new AiPlayer(), new ConsolePlayer());

                        break;
                    }
                    else if (line == "6")
                    {
                        Simulate(new RandomPlayer(), new RandomPlayer(), 10);

                        break;
                    }
                    else if (line == "7")
                    {
                        Simulate(new AiPlayer(), new RandomPlayer(), 10);

                        break;
                    }
                    else if (line == "8")
                    {
                        Simulate(new RandomPlayer(), new AiPlayer(), 10);

                        break;
                    }
                    else if (line == "0")
                    {
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine("Press [enter] for new game");

                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
            }
        }

        static void Simulate(IPlayer firstPlayer, IPlayer secondPlayer, int count)
        {
            int x = 0;
            int o = 0;
            int draw = 0;
            int firstWinner = 0;
            int secondWinner = 0;

            IPlayer first = firstPlayer;
            IPlayer second = secondPlayer;

            for (int i = 0; i < count; i++)
            {
                TicTacToeGame game = new TicTacToeGame(firstPlayer, secondPlayer);
                GameResult result = game.Play();


                if (result.Winner == Symbol.X && first == firstPlayer)
                {
                    firstWinner++;
                }
                if (result.Winner == Symbol.O && first == firstPlayer)
                {
                    secondWinner++;
                }
                if (result.Winner == Symbol.X && second == secondPlayer)
                {
                    secondWinner++;
                }
                if (result.Winner == Symbol.O && second == firstPlayer)
                {
                    firstWinner++;
                }
                if (result.Winner == Symbol.X)
                {
                    x++;
                }
                if (result.Winner == Symbol.O)
                {
                    o++;
                }
                if (result.Winner == Symbol.None)
                {
                    draw++;
                }

                (first, second) = (second, first);
            }

            Console.WriteLine($"Games played: {count}");
            Console.WriteLine($"Games won by X: {x}");
            Console.WriteLine($"Games won by O: {o}");
            Console.WriteLine($"Draw games: {draw}");
            Console.WriteLine($"{firstPlayer.GetType().Name} won games: {firstWinner}");
            Console.WriteLine($"{secondPlayer.GetType().Name} won games: {secondWinner}");
        }

        static void PlayGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            TicTacToeGame game = new TicTacToeGame(firstPlayer, secondPlayer);

            GameResult result = game.Play();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("Game over!");

            if (result.Winner == Symbol.None)
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine($"Winner: {result.Winner}");
            }

            Console.WriteLine(result.Board.ToString());

            Console.ResetColor();
        }
    }
}
