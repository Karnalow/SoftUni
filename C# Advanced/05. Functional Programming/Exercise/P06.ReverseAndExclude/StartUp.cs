using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ReverseAndExclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Console.WriteLine(String.Join(' ', numbers.Where(x => x % n != 0).ToList()));
        }
    }
}
