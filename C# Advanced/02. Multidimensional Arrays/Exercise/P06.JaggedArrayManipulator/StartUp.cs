using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] array = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] parts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                array[i] = new int[parts.Length];

                for (int j = 0; j < parts.Length; j++)
                {
                    array[i][j] = parts[j];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (array[row].Length == array[row + 1].Length)
                {
                    for (int currentElementFirstArray = 0;
                        currentElementFirstArray < array[row].Length;
                        currentElementFirstArray++)
                    {
                        array[row][currentElementFirstArray] = array[row][currentElementFirstArray] * 2;
                    }
                    for (int currentElementSecoundArray = 0;
                        currentElementSecoundArray < array[row].Length;
                        currentElementSecoundArray++)
                    {
                        array[row + 1][currentElementSecoundArray] = array[row + 1][currentElementSecoundArray] * 2;
                    }
                }
                else
                {
                    for (int currentElementFirstArray = 0;
                        currentElementFirstArray < array[row].Length;
                        currentElementFirstArray++)
                    {
                        array[row][currentElementFirstArray] = array[row][currentElementFirstArray] / 2;
                    }
                    for (int currentElementSecoundArray = 0;
                        currentElementSecoundArray < array[row + 1].Length;
                        currentElementSecoundArray++)
                    {
                        array[row + 1][currentElementSecoundArray] = array[row + 1][currentElementSecoundArray] / 2;
                    }
                }
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string commandName = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (commandName == "Add")
                {
                    if ((row >= 0 && row < array.Length) && (col >= 0 && col < array[row].Length))
                    {
                        array[row][col] += value;
                    }
                }
                else if (commandName == "Subtract")
                {
                    if ((row >= 0 && row < array.Length) && (col >= 0 && col < array[row].Length))
                    {
                        array[row][col] -= value;
                    }
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
