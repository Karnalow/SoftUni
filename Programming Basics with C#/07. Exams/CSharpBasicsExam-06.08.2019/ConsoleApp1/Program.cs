using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('|', 2 * n + 2));
            Console.WriteLine(new string('+', 2 * n + 2));
            Console.WriteLine(new string('|', n - 2) + "GARAGE" + new string('|', n - 2));

            for (int i = 0; i < n - 4; i++)
            {
                Console.WriteLine(new string('|', 2 * n + 2));
            }

            if (n - 3 >= 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("|" + new string('/', n - 3) + "|" + new string(' ', 4) + "|" + new string('\\', n - 3) + "|");
                }
            }
            else if (n - 4 < 1)
            {
                Console.WriteLine(new string('|', n - 1) + new string(' ', 4) + new string('|', n - 1));
            }

            Console.WriteLine(new string(' ', n - 2) + new string('/', 5));
        }
    }
}
