using System;
using System.Linq;

namespace P02.SumMatrixColumns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] matrix = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfRows = matrix[0];
            int numberOfCol = matrix[1];

            int[,] numbers = new int[numberOfRows, numberOfCol];

            for (int row = 0; row < numberOfRows; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < numberOfCol; col++)
                {
                    numbers[row, col] = line[col];
                }
            }

            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                int colSum = 0;

                for (int row = 0; row < numbers.GetLength(0); row++)
                {
                    colSum += numbers[row, col];
                }

                Console.WriteLine(colSum);
            }
        }
    }
}
