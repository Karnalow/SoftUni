using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Largest3Numbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>(); 

            string[] line = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (line[0] != "Revision")
            {
                string store = line[0];
                string product = line[1];
                double price = double.Parse(line[2]);

                if (!stores.ContainsKey(store))
                {
                    stores.Add(store, new Dictionary<string, double>());
                }

                if (!stores[store].ContainsKey(product))
                {
                    stores[store].Add(product, 0);
                }

                stores[store][product] = price;

                line = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var store in stores.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
