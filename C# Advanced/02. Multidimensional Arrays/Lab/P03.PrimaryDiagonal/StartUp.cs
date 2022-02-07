using System;
using System.Linq;

namespace P03.PrimaryDiagonal
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

            int sum = 0;
            int index = 0;

            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    sum += numbers[row, index];

                    index++;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
