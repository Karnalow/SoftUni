using System;
using System.Linq;

namespace EvenOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                if (number % 2 == 0)
                {
                    sumEven += number;
                }
                if (number % 2 != 0)
                {
                    sumOdd += number;
                }
            }

            int diff = sumEven - sumOdd;

            Console.WriteLine(diff);
        }
    }
}
