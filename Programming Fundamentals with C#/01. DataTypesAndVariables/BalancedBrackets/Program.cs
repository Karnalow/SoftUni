using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int openCount = 0;
            int closeCount = 0;

            string result = "";


            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                if (text == "(")
                {
                    openCount++;
                }
                else if (text == ")")
                {
                    closeCount++;

                    if (openCount - closeCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");

                        return;
                    }
                }
            }
            if (openCount == closeCount)
            {
                result = "BALANCED";
            }
            else
            {
                   result = "UNBALANCED";
            }

            Console.WriteLine(result);
        }
    }
}
