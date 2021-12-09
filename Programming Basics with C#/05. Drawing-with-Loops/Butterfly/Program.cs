using System;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var halfRowSize = n - 2;
            for (int i = 0; i < halfRowSize; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine("{0}\\ /{0}", new string('-', halfRowSize));
                else
                    Console.WriteLine("{0}\\ /{0}", new string('*', halfRowSize));
            }
            Console.WriteLine("{0} @ {0}", new string(' ', halfRowSize));
            for (int i = 0; i < halfRowSize; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine("{0}/ \\{0}", new string('-', halfRowSize));
                else
                    Console.WriteLine("{0}/ \\{0}", new string('*', halfRowSize));
            }
        }
    }
}
