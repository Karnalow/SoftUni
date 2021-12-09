using System;

namespace MultiplyEvensOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMultipleOfEvenAndOdds(num));
        }

        public static int GetSumOfEvenDigits(int num)
        {
            num = Math.Abs(num);

            int evenSum = 0;
            int digit = num;

            while (num > 0)
            {
                digit = num % 10;
                num = num / 10;

                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }
            }

            return evenSum;
        }

        public static int GetSumOfOddDigits(int num)
        {
            num = Math.Abs(num);

            int oddSum = 0;
            int digit = num;

            while (num > 0)
            {
                digit = num % 10;
                num = num / 10;

                if (digit % 2 != 0)
                {
                    oddSum += digit;
                }
            }
            return oddSum;
        }

        public static int GetMultipleOfEvenAndOdds(int num)
        {
            int multiply = GetSumOfOddDigits(num) * GetSumOfEvenDigits(num);

            return multiply;
        }
    }
}
