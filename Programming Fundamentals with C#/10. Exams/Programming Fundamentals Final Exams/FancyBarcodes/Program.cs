using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(@[\#]+)([A-Z][a-zA-Z\d]{4,}[A-Z])(@[\#]+)");

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                int digitCount = 0;
                string digits = string.Empty;

                if (pattern.IsMatch(barcode))
                {
                    foreach (var item in barcode)
                    {
                        if (Char.IsDigit(item))
                        {
                            digitCount++;
                            digits += item;
                        }
                    }

                    if (digitCount == 0)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else if (digitCount >= 1)
                    {
                        Console.WriteLine($"Product group: {digits}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
