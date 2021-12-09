using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTopNumber(num);
        }

        private static void PrintTopNumber(int num)
        {
            for (int i = 0; i <= num; i++)
            {
                string currentNumber = i.ToString();
                bool isOddDigit = false;
                int sumOfDigits = 0;

                foreach (var curr in currentNumber)
                {
                    int parseNumber = (int)curr;

                    if (parseNumber % 2 == 1)
                    {
                        isOddDigit = true;
                    }

                    sumOfDigits += parseNumber;
                }

                if (sumOfDigits % 8 == 0 && isOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
