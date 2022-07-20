using System;

namespace P02.RecursiveFactorial
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long factorial = 1;

            for (long i = n; i > 0; i--)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
