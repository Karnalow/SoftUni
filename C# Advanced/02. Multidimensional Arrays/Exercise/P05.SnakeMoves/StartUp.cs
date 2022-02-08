using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SnakeMoves
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = nums[0];
            int cols = nums[1];

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();
            int counter = 0;

            Queue<char> queue = new Queue<char>();

            int capacity = rows * cols;

            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = queue.Dequeue();
                    }
                }
                else
                {
                    for (int k = cols - 1; k > -1; k--)
                    {
                        matrix[i, k] = queue.Dequeue();
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
