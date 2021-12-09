using System;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricePerKgVegetables = double.Parse(Console.ReadLine());
            var pricePerKgFruits = double.Parse(Console.ReadLine());
            var TotalKgVegetables = int.Parse(Console.ReadLine());
            var TotalKgFruits = int.Parse(Console.ReadLine());
            if (pricePerKgFruits >= 0.00 && pricePerKgFruits <= 1000.00 || pricePerKgVegetables >= 0.00 && pricePerKgVegetables <= 1000.00 || TotalKgVegetables >= 0.00 && TotalKgVegetables <= 1000.00 || TotalKgFruits >= 0.00 && TotalKgFruits <= 1000.00)
            {
                var TotalMoneyVegetables = pricePerKgVegetables * TotalKgVegetables;
                var TotalMoneyFruits = pricePerKgFruits * TotalKgFruits;
                var Total = TotalMoneyFruits + TotalMoneyVegetables;
                var BGNtoEUR = Total / 1.94;
                Console.WriteLine(BGNtoEUR);
            }
            else
                Console.WriteLine("Error");
        }
    }
}
