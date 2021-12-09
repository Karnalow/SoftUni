using System;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            double investInUSD = double.Parse(Console.ReadLine());
            double pricePerBitcoinInUSD = double.Parse(Console.ReadLine());
            int bait = int.Parse(Console.ReadLine());
            double purchesBitcoin = investInUSD / pricePerBitcoinInUSD;
            double expensesForPurches = purchesBitcoin * (bait * 1024) / 100000000;
            double afterExpensesForPurches = purchesBitcoin - expensesForPurches;
            double ProgramarPayment = afterExpensesForPurches * 0.10;
            double TaxInUSD = expensesForPurches  * pricePerBitcoinInUSD;
            double TotalBitcoinAfterExpenses = afterExpensesForPurches - ProgramarPayment;
            Console.WriteLine($"Total bitcoin after expenses: {TotalBitcoinAfterExpenses:f5} BTC");
            Console.WriteLine($"Tax payed: {TaxInUSD:f2} USD");
            Console.WriteLine($"Programmer`s payment: {ProgramarPayment:f5} BTC");
        }
    }
}
