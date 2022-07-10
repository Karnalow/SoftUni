using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CustomComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] evenNumbers = numbers.Where(x => x % 2 == 0)
                .ToArray();

            Array.Sort(evenNumbers);

            int[] oddNumbers = numbers.Where(x => x % 2 != 0)
                .ToArray();

            Array.Sort(oddNumbers);

            Console.WriteLine(string.Join(" ", evenNumbers.Concat(oddNumbers)));
        }
    }
}
