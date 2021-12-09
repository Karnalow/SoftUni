using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";

            List<string> products = new List<string>();

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double sum = 0;

            while (input != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    products.Add(name);

                    sum += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            Console.WriteLine(string.Join(Environment.NewLine, products));

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
