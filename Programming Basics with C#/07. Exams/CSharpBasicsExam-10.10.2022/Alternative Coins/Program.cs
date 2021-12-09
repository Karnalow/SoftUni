using System;

namespace Alternative_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var purchesBitcoin = double.Parse(Console.ReadLine());
            var firstPricePerBitcoin = double.Parse(Console.ReadLine());
            var momentPricePerBitcoin = double.Parse(Console.ReadLine());
            var ethereumNeed = double.Parse(Console.ReadLine());
            var neoNeed = double.Parse(Console.ReadLine());
            var profitFromBitcoin = purchesBitcoin * momentPricePerBitcoin - purchesBitcoin * firstPricePerBitcoin;
            var ethereumPrice = momentPricePerBitcoin * 0.075;
            var neoPrice = ethereumPrice * 0.40;
            var allPrice = ethereumPrice * ethereumNeed + neoPrice * neoNeed;

            if (profitFromBitcoin < allPrice)
            {
                var neededMoney = allPrice - profitFromBitcoin;
                Console.WriteLine("Stefcho does not have enough money to make this investment.");
                Console.WriteLine($"He needs {neededMoney:f2} more in profits.");
            }
            else
            {
                Console.WriteLine($"Stefcho bought {ethereumNeed:f4} Ethereum at a price of {ethereumPrice:f4}");
                Console.WriteLine($"Stefcho bought {neoNeed:f4} Neo at a price of {neoPrice:f4}");
                var remainingMoney = profitFromBitcoin - allPrice;
                Console.WriteLine($"Stefcho has {remainingMoney:f2} profits left to spend.");
            }
        }
    }
}
