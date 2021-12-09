using System;

namespace Coin_Rating
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            double DOGE = 0;
            double IOTA = 0;
            double NEO = 0;
            double ESTD = 0;
            int countDOGE = 0;
            int countIOTA = 0;
            int countNEO = 0;
            int countESTD = 0;

            for (int i = 1; i <= n; i++)
            {
                var name = Console.ReadLine();
                var coin = double.Parse(Console.ReadLine());
                if (name == "DOGE")
                {
                    DOGE = DOGE + coin * 0.07;
                    countDOGE++;
                }
                if (name == "IOTA")
                {
                    IOTA = IOTA + coin * 1.44;
                    countIOTA++;
                }
                if (name == "NEO")
                {
                    NEO = NEO + coin * 28.50;
                    countNEO++;
                }
                if (name == "ESTD")
                {
                    ESTD = ESTD + coin * 25.00;
                    countESTD++;
                }
            }

            var AllPrice = ESTD + NEO + IOTA + DOGE;
            var priceDOGE = (DOGE / AllPrice) * 100;
            var priceIOTA = (IOTA / AllPrice) * 100;
            var priceNEO = (NEO / AllPrice) * 100;
            var priceESTD = (ESTD / AllPrice) * 100;

            Console.WriteLine($"Total votes = {n}, Money in market = {AllPrice:f2} EUR");
            Console.WriteLine($"DOGE's contribution: {priceDOGE:f2}%; People who use DOGE: {countDOGE}");
            Console.WriteLine($"IOTA's contribution: {priceIOTA:f2}%; People who use IOTA: {countIOTA}");
            Console.WriteLine($"NEO's contribution: {priceNEO:f2}%; People who use NEO: {countNEO}");
            Console.WriteLine($"ESTD's contribution: {priceESTD:f2}%; People who use ESTD: {countESTD}");
        }
    }
}
