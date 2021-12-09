using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string sign = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            MakeAction(num1, sign, num2);
        }

        public static void MakeAction(int num1, string sign, int num2)
        {
            if (sign == "+")
            {
                Console.WriteLine(num1 + num2);
            }
            else if (sign == "-")
            {
                Console.WriteLine(num1 - num2);
            }
            else if (sign == "*")
            {
                Console.WriteLine(num1 * num2);
            }
            else if (sign == "/")
            {
                Console.WriteLine(num1 / num2);
            }
        }
    }
}
