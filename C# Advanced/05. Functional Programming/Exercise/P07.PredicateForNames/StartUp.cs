using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> namesWithLeghtN = name => name.Count() - n == 0;

            Console.WriteLine(string.Join(Environment.NewLine, names.FindAll(namesWithLeghtN)));
        }
    }
}
