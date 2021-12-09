using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());

            Console.WriteLine(Pow(num, pow));
        }

        public static double Pow(double num, double pow)
        {
            double numPow = Math.Pow(num, pow);

            return numPow;
        }
    }
}
