using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            string resource = Console.ReadLine();
            int quantity;

            while (resource != "stop")
            {
                quantity = int.Parse(Console.ReadLine());

                if (!counts.ContainsKey(resource))
                {
                    counts.Add(resource, quantity);
                }
                else
                {
                    counts[resource] += quantity;
                }

                resource = Console.ReadLine();
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}
