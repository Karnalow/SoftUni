using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PeriodicTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < element.Length; j++)
                {
                    if (!elements.Contains(element[j]))
                    {
                        elements.Add(element[j]);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', elements.OrderBy(x => x)));
        }
    }
}
