using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = number => number.Min();

            Console.WriteLine(smallestNumber(numbers));
        }
    }
}
