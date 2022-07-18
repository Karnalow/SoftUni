using System;

namespace P05.Survivor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] beach = new string[rows][];

            int myTokens = 0;
            int opponentTokens = 0;

            for (int i = 0; i < rows; i++)
            {
                string[] symbols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                beach[i] = symbols;
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Gong")
            {
                if (command[0] == "Find")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);

                    if ((row >= 0 && row < beach.Length) &&
                        (col >= 0 && col < beach[row].Length))
                    {
                        if (beach[row][col] == "T")
                        {
                            myTokens++;
                            beach[row][col] = "-";
                        }
                    }
                }
                else if (command[0] == "Opponent")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    string direction = command[3];

                    if ((row >= 0 && row < beach.Length) &&
                        (col >= 0 && col < beach[row].Length))
                    {
                        if (beach[row][col] == "T")
                        {
                            opponentTokens++;
                            beach[row][col] = "-";
                        }
                    }

                    int opponentSteps = 3;

                    if (direction == "up")
                    {
                        for (int i = 0; i < opponentSteps; i++)
                        {
                            if ((row - 1 >= 0 && row < beach.Length) &&
                                (col >= 0 && col < beach[row].Length))
                            {
                                row--;

                                if (beach[row][col] == "T")
                                {
                                    opponentTokens++;
                                    beach[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = 0; i < opponentSteps; i++)
                        {
                            if ((row >= 0 && row + 1 < beach.Length) &&
                                (col >= 0 && col < beach[row].Length))
                            {
                                row++;

                                if (beach[row][col] == "T")
                                {
                                    opponentTokens++;
                                    beach[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = 0; i < opponentSteps; i++)
                        {
                            if ((row >= 0 && row + 1 < beach.Length) &&
                                (col - 1 >= 0 && col < beach[row].Length))
                            {
                                col--;

                                if (beach[row][col] == "T")
                                {
                                    opponentTokens++;
                                    beach[row][col] = "-";
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < opponentSteps; i++)
                        {
                            if ((row >= 0 && row + 1 < beach.Length) &&
                                (col - 1 >= 0 && col + 1 < beach[row].Length))
                            {
                                col++;

                                if (beach[row][col] == "T")
                                {
                                    opponentTokens++;
                                    beach[row][col] = "-";
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(' ', beach[row]));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
