using System;

namespace Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            int years = 18;
            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                    money -= 12000;
                else
                    money -= (12000 + 50 * years);
                years++;
            }
            if (money >= 0)
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars left.");
            else
                Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
        }
    }
}
