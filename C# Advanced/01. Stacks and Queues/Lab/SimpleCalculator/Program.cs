using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(input.Reverse());

            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string symbol = stack.Pop();

                if (symbol == "+")
                {
                    result += int.Parse(stack.Pop());
                }
                else if (symbol == "-")
                {
                    result -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}
