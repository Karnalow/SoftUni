using System;
using System.Linq;

namespace P04.AddVAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] numbersWithVAT = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(double.Parse)
                   .Select(x => x * 1.2)
                   .ToArray();

            foreach (var number in numbersWithVAT)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
