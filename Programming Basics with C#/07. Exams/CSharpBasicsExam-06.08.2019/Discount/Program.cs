using System;

namespace Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            var carModel = Console.ReadLine();
            var VIN = int.Parse(Console.ReadLine());
            var condition = Console.ReadLine();
            var price = double.Parse(Console.ReadLine());
            var profit = price * 0.15;
            if (condition == "good" && VIN < 90000 && VIN % 2 == 0 && profit > 400)
            {
                Console.WriteLine($"yes - {carModel}");
                Console.WriteLine($"profit - {profit:f2}");
            }
            else
                Console.WriteLine("no");
            if (condition == "bad")
                Console.WriteLine("The car is in bad condition");
            if (VIN >= 90000)
                Console.WriteLine($"VIN {VIN} is not valid");
            if (profit < 400)
                Console.WriteLine($"Cannot make discount, profit too low - {profit:f2}");
        }
    }
}
