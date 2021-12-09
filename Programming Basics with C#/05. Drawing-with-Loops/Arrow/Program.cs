using System;

namespace Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var outerDots = (n - 1) / 2;
            var innerDots = n - 2;
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('#', n));
            for (int i = 0; i < n - 2; i++)
                Console.WriteLine("{0}#{1}#{0}", new string('.', innerDots), new string('#', innerDots));
            Console.WriteLine("{0}{1}{0}", new string('#', outerDots + 1), new string('.', n));
            outerDots = 1;
            innerDots = 2 * n - 5;
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}#{1}#{0}", new string('.', innerDots), new string('#', innerDots));
                outerDots++;
                innerDots--;
            }
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots));
        }
    }
}
