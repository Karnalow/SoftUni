using System;

namespace Resale
{
    class Program
    {
        static void Main(string[] args)
        {
            var carModel = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());
            double daysIn = int.Parse(Console.ReadLine());
            double taks = price + (price * 0.20) + 275;
            double rent = daysIn * 20;
            double afterTaks = taks + rent;
            double profit = afterTaks * 0.15;
            double sell = taks + rent + profit;
            Console.WriteLine($"The {carModel} with initial price of {price:f2} BGN will sell for {sell:f2} BGN");
            Console.WriteLine($"Profit: {profit:f2} BGN");
        }
    }
}
