using System;
using System.Linq;

namespace P06.Jagged_ArrayModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] arrays = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] parts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                arrays[i] = new int[parts.Length];

                for (int j = 0; j < parts.Length; j++)
                {
                    arrays[i][j] = parts[j];
                }
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                string commandName = command[0];
                int arrayIndex = int.Parse(command[1]);
                int arrayElement = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (arrayIndex < 0 || arrayIndex >= arrays.Length ||
                    arrayElement < 0 || arrayElement >= arrays[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (commandName == "Add")
                {
                    arrays[arrayIndex][arrayElement] += value;
                }
                else if (commandName == "Subtract")
                {
                    arrays[arrayIndex][arrayElement] -= value;
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
