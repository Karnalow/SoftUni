using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var food = Console.ReadLine().ToLower();
            var city = Console.ReadLine().ToLower();
            var num = double.Parse(Console.ReadLine());
            if (city == "sofia")
            {
                if (food == "coffee") Console.WriteLine(num * 0.50);
                if (food == "water") Console.WriteLine(num * 0.80);
                if (food == "beer") Console.WriteLine(num * 1.20);
                if (food == "sweets") Console.WriteLine(num * 1.45);
                if (food == "peanuts") Console.WriteLine(num * 1.60);
            }
            if (city == "plovdiv")
            {
                if (food == "coffee") Console.WriteLine(num * 0.40);
                if (food == "water") Console.WriteLine(num * 0.70);
                if (food == "beer") Console.WriteLine(num * 1.15);
                if (food == "sweets") Console.WriteLine(num * 1.30);
                if (food == "peanuts") Console.WriteLine(num * 1.50);
            }
            if (city == "varna")
            {
                if (food == "coffee") Console.WriteLine(num * 0.45);
                if (food == "water") Console.WriteLine(num * 0.70);
                if (food == "beer") Console.WriteLine(num * 1.10);
                if (food == "sweets") Console.WriteLine(num * 1.35);
                if (food == "peanuts") Console.WriteLine(num * 1.55);
            }
        }
    }
}
