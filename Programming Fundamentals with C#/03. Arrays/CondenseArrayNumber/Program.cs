using System;
using System.Linq;

namespace CondenseArrayNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counter = numbers.Length;
            while (counter > 1)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                }
                counter--;
            }
            Console.WriteLine(numbers[0]);
        }
    }
}
