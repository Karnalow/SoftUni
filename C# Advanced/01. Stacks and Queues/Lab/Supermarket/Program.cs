using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Queue<string> names = new Queue<string>();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, names));

                    names.Clear();
                }
                else
                {
                    names.Enqueue(name);
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
