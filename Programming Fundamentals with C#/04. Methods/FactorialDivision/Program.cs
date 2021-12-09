using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorialFirstNumber = GetFactorial(num1);
            double factorialSecoundNumber = GetFactorial(num2);

            double result = factorialFirstNumber / factorialSecoundNumber;

            Console.WriteLine($"{result:f2}");
        }

        private static double GetFactorial(int num1)
        {
            double result = 1;

            while (num1 != 1)
            {
                result *= num1;
                num1 = num1 - 1;
            }

            return result;
        }
    }
}
