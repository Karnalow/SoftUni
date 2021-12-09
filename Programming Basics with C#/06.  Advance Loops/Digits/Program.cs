using System;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var firstNumber = number / 100;
            var secondNumber = (number / 10) % 10;
            var thitdNumber = number % 10;
            var n = firstNumber + secondNumber;
            var m = firstNumber + thitdNumber;
            for (int i = 1; i <= n; i++)
            {
                for (int d = 1; d <= m; d++)
                {

                    if (number % 5 == 0)
                    {
                        number = number - firstNumber;
                    }
                    else if (number % 3 == 0)
                    {
                        number = number - secondNumber;
                    }
                    else if ((number % 5 != 0) && (number % 3 != 0))
                    {
                        number = number + thitdNumber;
                    }
                    Console.Write(number);
                    if (d < m)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
