using System;
using System.Linq;

namespace P02.SquaresinMatrix
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

            char[,] numbers = new char[numberOfRows, numberOfCol];

            for (int row = 0; row < numberOfRows; row++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < numberOfCol; col++)
                {
                    numbers[row, col] = line[col];
                }
            }

            int countOfCoincidence = 0;

            for (int row = 0; row < numbers.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 1; col++)
                {
                    int sum = numbers[row, col] + numbers[row, col + 1] +
                        numbers[row + 1, col] + numbers[row + 1, col + 1];

                    if (numbers[row, col] == numbers[row, col + 1] &&
                        numbers[row, col + 1] == numbers[row + 1, col] &&
                        numbers[row + 1, col] == numbers[row + 1, col + 1])
                    {
                        countOfCoincidence++;
                    }
                }
            }

            Console.WriteLine(countOfCoincidence);
        }
    }
}
