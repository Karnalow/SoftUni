using System;

namespace Seasonal_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            var carModel = Console.ReadLine();
            var carType = Console.ReadLine();
            var season = Console.ReadLine();
            var condition = Console.ReadLine();
            var firtsPrice = double.Parse(Console.ReadLine());
            var needProfit = double.Parse(Console.ReadLine());
            double profit = 0;
            if (carType == "sum" && condition == "perfect")
                profit = firtsPrice * 0.30;
            else if (carType == "suv" && condition == "good")
                profit = firtsPrice * 0.20;
            else if (carType == "suv" && condition == "bad")
                profit = firtsPrice * 0.10;
            else if (carType == "sedan" && condition == "perfect")
                profit = firtsPrice * 0.25;
            else if (carType == "sedan" && condition == "good")
                profit = firtsPrice * 0.15;
            else if (carType == "sedan" && condition == "bad")
                profit = firtsPrice * 0.10;
            if (season == "winter")
                profit = profit - 200;
            if (profit >= needProfit)
                Console.WriteLine($"The profit on {carModel} will be good - {profit:f2} BGN");
            else
            {
                var needed = needProfit - profit;
                Console.WriteLine("The car is not worth selling now");
                Console.WriteLine($"Need {needed:f2} more profit");
            }
        }
    }
}
