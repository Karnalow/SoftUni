using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
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
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < numberOfCol; col++)
                {
                    numbers[row, col] = line[col];
                }
            }

            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < numbers.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 1; col++)
                {
                    int sum = numbers[row, col] + numbers[row, col + 1] +
                        numbers[row + 1, col] + numbers[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = maxSumRow; row < maxSumRow + 2; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 2; col++)
                {
                    Console.Write(numbers[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
