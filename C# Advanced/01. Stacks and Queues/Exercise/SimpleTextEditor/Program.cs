using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            StringBuilder builder = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(builder.ToString());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int commandNumber = int.Parse(cmdArg[0]);

                if (commandNumber == 1)
                {
                    string argument = cmdArg[1];

                    builder.Append(argument);
                    stack.Push(builder.ToString());
                }
                else if (commandNumber == 2)
                {
                    int argument = int.Parse(cmdArg[1]);

                    builder.Remove(builder.Length - argument, argument);
                    stack.Push(builder.ToString());
                }
                else if (commandNumber == 3)
                {
                    int argument = int.Parse(cmdArg[1]);

                    Console.WriteLine(builder[argument - 1]);
                }
                else if (commandNumber == 4)
                {
                    stack.Pop();

                    builder = new StringBuilder();

                    builder.Append(stack.Peek());
                }
            }
        }
    }
}
