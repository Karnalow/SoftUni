using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productsPrices = new Dictionary<string, decimal>();
            Dictionary<string, int> productsQuantityies = new Dictionary<string, int>();

            string[] command =
                Console.ReadLine()
                .Split();

            while (command[0] != "buy")
            {
                string name = command[0];
                decimal price = decimal.Parse(command[1]);
                int quantity = int.Parse(command[2]);


                if (!productsQuantityies.ContainsKey(name))
                {
                    productsQuantityies[name] = quantity;
                }
                else
                {
                    productsQuantityies[name] += quantity;
                }

                productsPrices[name] = price;

                command =
                Console.ReadLine()
                .Split();
            }

            foreach (var product in productsQuantityies)
            {
                Console.WriteLine($"{product.Key} -> {(productsQuantityies[product.Key] * productsPrices[product.Key]):f2}");
            }
        }
    }
}
