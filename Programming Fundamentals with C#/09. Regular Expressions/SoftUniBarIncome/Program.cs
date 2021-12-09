using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> names =
                new Dictionary<string, Dictionary<string, decimal>>();

            string name = @"%[A-Z][a-z]+%";
            string product = @"<[A-Z][a-z]+>";
            string count = @"\|\d+\|";
            string price = @"\d+\.?\d+\$";

            decimal totalIncome = 0;

            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match matchName = Regex.Match(input, name);
                Match matchProduct = Regex.Match(input, product);
                Match matchCount = Regex.Match(input, count);
                Match matchPrice = Regex.Match(input, price);

                if (matchName.Success && matchProduct.Success &&
                    matchCount.Success && matchPrice.Success)
                {
                    string clearName = matchName.Value.Substring(1, matchName.Length - 2);
                    string clearProduct = matchProduct.Value.Substring(1, matchProduct.Length - 2);
                    int clearCount = int.Parse(matchCount.Value.Substring(1, matchCount.Length - 2));
                    decimal clearPrice = decimal.Parse(matchPrice.Value.Substring(0, matchPrice.Length - 1));

                    decimal totalPriceForCustumer = clearCount * clearPrice;

                    totalIncome += totalPriceForCustumer;

                    Console.WriteLine($"{clearName}: {clearProduct} - {totalPriceForCustumer:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
