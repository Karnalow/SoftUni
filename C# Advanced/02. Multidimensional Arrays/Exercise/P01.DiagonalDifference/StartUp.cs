using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int sizeOfSquareMatrix = int.Parse(Console.ReadLine());

            int[,] numbers = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];

            for (int row = 0; row < sizeOfSquareMatrix; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfSquareMatrix; col++)
                {
                    numbers[row, col] = line[col];
                }
            }

            //For primary diagonal

            int primarySum = 0;
            int primaryIndex = 0;

            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    primarySum += numbers[row, primaryIndex];

                    primaryIndex++;
                }
            }

            // For secondary diagonal

            int secondarySum = 0;
            int secondaryIndex = numbers.GetLength(0) - 1;

            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    secondarySum += numbers[row, secondaryIndex];

                    secondaryIndex--;
                }
            }

            int sum = Math.Abs(primarySum - secondarySum);

            Console.WriteLine(sum);
        }
    }
}
