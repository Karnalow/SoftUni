using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integer = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToList();

            List<string> word = Console.ReadLine()
                                       .Split()
                                       .ToList();
        }
    }
}
