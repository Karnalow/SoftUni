using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfElementsInFirstCollection = array[0];
            int numberOfElementsInSecondCollection = array[1];

            List<int> firstCollection = new List<int>();
            List<int> secondCollection = new List<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < numberOfElementsInFirstCollection; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstCollection.Add(number);
            }

            for (int i = 0; i < numberOfElementsInSecondCollection; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondCollection.Add(number);
            }

            foreach (var number in firstCollection)
            {
                if (secondCollection.Contains(number))
                {
                    if (!result.Contains(number))
                    {
                        result.Add(number);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}
