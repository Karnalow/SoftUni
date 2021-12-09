using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targetsWithValue =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();

            int count = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < 0 || index >= targetsWithValue.Length || targetsWithValue[index] == -1)
                {
                    input = Console.ReadLine();

                    continue;
                }

                int shotTarget = targetsWithValue[index];
                targetsWithValue[index] = -1;
                count++;

                for (int i = 0; i < targetsWithValue.Length; i++)
                {
                    if (targetsWithValue[i] == -1)
                    {
                        continue;
                    }
                    if (targetsWithValue[i] > shotTarget)
                    {
                        targetsWithValue[i] -= shotTarget;
                    }
                    else
                    {
                        targetsWithValue[i] += shotTarget;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(' ', targetsWithValue)}");
        }
    }
}
