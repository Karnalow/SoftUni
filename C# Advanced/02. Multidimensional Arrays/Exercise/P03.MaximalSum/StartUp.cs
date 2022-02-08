using System;
using System.Linq;

namespace P03.MaximalSum
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

            /*
             1 5 5 2 4
             2 1 4 14 3
             3 7 11 2 8
             4 8 12 16 4
             */

            int maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < numbers.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 2; col++)
                {
                    int sum = numbers[row, col] + numbers[row, col + 1] + numbers[row, col + 2] +
                        numbers[row + 1, col] + numbers[row + 1, col + 1] + numbers[row + 1, col + 2] +
                        numbers[row + 2, col] + numbers[row + 2, col + 1] + numbers[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxSumRow; row < maxSumRow + 3; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 3; col++)
                {
                    Console.Write(numbers[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
