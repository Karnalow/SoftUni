using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expressions = Console.ReadLine();
            Stack<char> openParentheses = new Stack<char>();
            bool isBalanced = true;

            foreach (var c in expressions)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    openParentheses.Push(c);
                }
                else
                {
                    if (!openParentheses.Any())
                    {
                        isBalanced = false;
                        break;
                    }

                    char currentOpenParentheses = openParentheses.Pop();

                    bool isRoundBalanced = currentOpenParentheses == '(' && c == ')';
                    bool isCurlyBalanced = currentOpenParentheses == '{' && c == '}';
                    bool isSquareBalanced = currentOpenParentheses == '[' && c == ']';

                    if (isRoundBalanced == false &&
                        isSquareBalanced == false &&
                        isCurlyBalanced == false)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
