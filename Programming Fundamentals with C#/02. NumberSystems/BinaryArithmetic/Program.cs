using System;

namespace BinaryArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string bet = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            if (bet == "+")
            {
                Console.WriteLine(a + b);
            }
            else if (bet == "-")
            {
                Console.WriteLine(a - b);
            }
            else if (bet == "*")
            {
                Console.WriteLine(a * b);
            }
            else if (bet == "/")
            {
                Console.WriteLine(a / b);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
