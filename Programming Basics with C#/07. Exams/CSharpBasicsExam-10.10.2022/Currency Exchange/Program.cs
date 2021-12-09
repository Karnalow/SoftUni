using System;

namespace Currency_Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var currency = Console.ReadLine();
            var investEUR = double.Parse(Console.ReadLine());
            var minimalXRP = 80 * 0.22;
            var minimalBTC = 0.0001 * 6400;
            var minimalETH = 0.0099 * 250;

            if (currency == "XRP" && investEUR >= minimalXRP || currency == "BTC" && investEUR >= minimalBTC || currency == "ETH" && investEUR >= minimalETH)
            {
                if (investEUR > 1000)
                {
                    investEUR = investEUR * 0.1 + investEUR;
                }
                if (currency == "XRP" && investEUR / 0.22 > 1000 && investEUR / 0.22 < 2500)
                {
                    var coin = investEUR / 0.22;
                    coin = coin + coin * 0.05;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
                if (currency == "XRP" && investEUR / 0.22 >= 2500)
                {
                    var coin = investEUR / 0.22;
                    coin = coin + coin * 0.10;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
                if (currency == "BTC" && investEUR / 6400 > 10)
                {
                    var coin = investEUR / 6400;
                    coin = coin + coin * 0.02;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
                if (currency == "ETH")
                {
                    var coin = investEUR / 250;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
                if (currency == "BTC" && investEUR / 6400 <= 10)
                {
                    var coin = investEUR / 6400;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
                if (currency == "XRP" && investEUR / 0.22 < 2500)
                {
                    var coin = investEUR / 0.22;
                    Console.WriteLine($"Successfully purchased {coin:f3} {currency}");
                }
            }
            else if (investEUR < minimalXRP || investEUR < minimalBTC || investEUR < minimalETH)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                Console.WriteLine($"EUR to {currency} is not supported.");
            }
        }
    }
}