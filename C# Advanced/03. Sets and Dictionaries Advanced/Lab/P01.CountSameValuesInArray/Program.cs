using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var number in input)
            {
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, +1);
                }
                else
                {
                    numbers[number]++;
                }
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
