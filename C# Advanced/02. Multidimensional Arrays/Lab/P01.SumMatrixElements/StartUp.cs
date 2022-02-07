using System;
using System.Linq;

namespace P01.SumMatrixElements
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

            int [,] numbers = new int[numberOfRows, numberOfCol];

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

            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(numberOfRows);
            Console.WriteLine(numberOfCol);
            Console.WriteLine(sum);
        }
    }
}
