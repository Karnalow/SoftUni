using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] matrix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfRows = matrix[0];
            int numberOfCol = matrix[1];

            string[,] charecters = new string[numberOfRows, numberOfCol];

            for (int row = 0; row < numberOfRows; row++)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < numberOfCol; col++)
                {
                    charecters[row, col] = line[col];
                }
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "END")
            {
                if (command.Length == 5)
                {
                    string commandName = command[0];
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if (commandName != "swap" || row1 >= numberOfRows || row2 >= numberOfRows ||
                        col1 >= numberOfCol || col2 >= numberOfCol)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firstElement = charecters[row1, col1];
                        string secondElement = charecters[row2, col2];

                        charecters[row2, col2] = firstElement;
                        charecters[row1, col1] = secondElement;

                        for (int row = 0; row < charecters.GetLength(0); row++)
                        {
                            for (int col = 0; col < charecters.GetLength(1); col++)
                            {
                                Console.Write(charecters[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
