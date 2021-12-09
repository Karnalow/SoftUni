using System;

namespace RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int range = 2; range <= n; range++)
            {
                string isSpecial = "true";
                for (int space = 2; space < range; space++)
                {
                    if (range % space == 0)
                    {
                        isSpecial = "false";
                        break;
                    }
                }

                Console.WriteLine("{0} -> {1}", range, isSpecial);
            }

        }
    }
}
