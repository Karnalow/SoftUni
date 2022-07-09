using System;
using System.Linq;

namespace P02.KnightsOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> action = (x) => Console.WriteLine($"Sir {x}");

            names.ToList().ForEach(action);
        }
    }
}
