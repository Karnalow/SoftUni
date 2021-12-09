using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int digitSum = 0;
                int digit = num;

                while (digit > 0)
                {
                    digitSum += digit % 10;
                    digit = digit / 10;
                }

                bool isSpecial = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);

                Console.WriteLine($"{num} -> {isSpecial}");
            }
        }
    }
}
