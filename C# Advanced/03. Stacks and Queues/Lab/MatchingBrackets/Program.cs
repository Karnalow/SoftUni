using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> indices = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indices.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openBrackedIndex = indices.Pop();
                    int closedBrackedIndex = i;

                    Console.WriteLine(expression.Substring(openBrackedIndex, closedBrackedIndex - openBrackedIndex + 1));
                }
            }
        }
    }
}
