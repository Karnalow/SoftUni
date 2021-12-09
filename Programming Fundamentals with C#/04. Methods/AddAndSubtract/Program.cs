using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = Sum(num1, num2, num3);

            Console.WriteLine(sum);
        }

        private static int Sum(int num1, int num2, int num3)
        {
            int sumFirstAndSecound = num1 + num2;

            return Subtract(sumFirstAndSecound, num3);
        }

        private static int Subtract(int sumFirstAndSecound, int num3)
        {
            return sumFirstAndSecound - num3;
        }
    }
}
