using System;

namespace Online_Ads
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var gasCars = 0.0;
            var dieselCars = 0.0;
            for (int i = 1; i <= n; i++)
            {
                var carModel = Console.ReadLine();
                var carType = Console.ReadLine();
                var carOil = Console.ReadLine();
                var status = Console.ReadLine();
                var carPrice = decimal.Parse(Console.ReadLine());
                var carKilometers = int.Parse(Console.ReadLine());
                Console.WriteLine($"Car model - {carModel}");
                if (carType == "coupe" && carOil == "gasoline" && carPrice <= 100000)
                {
                    Console.WriteLine("Category - sport");
                }
                else if (carType == "coupe" && carOil == "gasoline" && carPrice > 100000)
                {
                    Console.WriteLine("Category - supersport");
                }
                if (carType == "coupe" && carOil == "diesel")
                {
                    Console.WriteLine("Category - ecosport");
                }
                if (carType == "sedan" && carOil == "gasoline" && carPrice <= 80000)
                {
                    Console.WriteLine("Category - executive");
                }
                else if (carType == "sedan" && carOil == "gasoline" && carPrice > 80000)
                {
                    Console.WriteLine("Category - limousine");
                }
                if (carType == "sedan" && carOil == "diesel")
                {
                    Console.WriteLine("Category - economic");
                }
                if (status == "vip")
                {
                    carPrice = carPrice + 200;
                }
                Console.WriteLine($"Type - {carType}");
                Console.WriteLine($"Fuel - {carOil}");
                Console.WriteLine($"Kilometers - {carKilometers}");
                Console.WriteLine($"Price - {carPrice:f2}");
                if (carOil == "diesel")
                {
                    dieselCars++;
                }
                else
                {
                    gasCars++;
                }
            }
            Console.WriteLine($"Gasoline cars: {((gasCars / n) * 100):f2}%");
            Console.WriteLine($"Diesel cars: {((dieselCars / n) * 100):f2}%");
        }
    }
}
