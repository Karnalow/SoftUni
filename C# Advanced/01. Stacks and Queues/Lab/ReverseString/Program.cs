using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            string output = string.Empty;

            while (stack.Count > 0)
            {
                output += stack.Pop();
            }

            Console.Write(output);
            Console.WriteLine();
        }
    }
}