using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> listSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string option = Console.ReadLine();
            
            int lowerBound = listSize.Min();
            int upperBound = listSize.Max();

            List<int> list = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                list.Add(i);
            }

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;

            if (option == "odd")
            {
                Console.WriteLine(String.Join(' ', list.FindAll(odd)));
            }
            else if (option == "even")
            {
                Console.WriteLine(String.Join(' ', list.FindAll(even)));
            }
        }
    }
}
