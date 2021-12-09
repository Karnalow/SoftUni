using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckTheNumbers(num1, num2, num3));
        }

        private static string CheckTheNumbers(int num1, int num2, int num3)
        {
            if ((num1 < 0 && num2 > 0 && num3 > 0) ||
                (num1 > 0 && num2 < 0 && num3 > 0) || 
                (num1 > 0 && num2 > 0 && num3 < 0) ||
                (num1 < 0 && num2 < 0 && num3 < 0))
            {
                return "negative";
            }
            else if ((num1 == 0 || num2 == 0 || num3 == 0))
            {
                return "zero";
            }
            else
            {
                return "positive";
            }
        }
    }
}
