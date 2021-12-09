using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int f0 = 1;
            int f1 = 1;
            int f2 = 2;

            Console.Write($"{f0} {f1} {f2} ");
            
            for (int i = 0; i < n - 3; i++)
            {
                int fNext = f0 + f1 + f2;
                f0 = f1;
                f1 = f2;
                f2 = fNext;

                Console.Write(f2 + " ");
            }
        }
    }
}
