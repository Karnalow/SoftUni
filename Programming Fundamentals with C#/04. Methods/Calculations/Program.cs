using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Calculate(command, num1, num2);
        }

        static void Calculate(string command, int num1, int num2)
        {
            if (command == "subtract")
            {
                Console.WriteLine(num1 - num2);
            }
            else if (command == "add")
            {
                Console.WriteLine(num1 + num2);
            }
            else if (command == "multiply")
            {
                Console.WriteLine(num1 * num2);
            }
            else if (command == "divide")
            {
                Console.WriteLine(num1 / num2);
            }
        }
    }
}
