using System;

namespace New_Coin
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var spaces = n * 2;
            var lines = n - 1;
            var dashes = 6;

            Console.Write(new string(' ', spaces));
            Console.Write(new string('\\', n));
            Console.WriteLine(new string('/', n));

            spaces -= 2;

            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine("{0}{1}{2}{3}", 
                    new string(' ', spaces),
                    new string('\\', lines),
                    new string('-', dashes),
                    new string('/', lines));

                lines--;
                dashes += 6;
                spaces -= 2;
            }

            if (n % 2 == 0)
            {
                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', n * 4));
                }
            }
            else
            {
                for (int i = 0; i < (n - 3) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', n * 4));
                }
            }
            Console.WriteLine("|{0}{1} ESTD {2}{0}|",
                new string('~', n - 1),
                new string('/', n * 2 - 3),
                new string('\\', n * 2 - 3));
            if (n % 2 == 0)
            {
                for (int i = 0; i < (n - 2) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', n * 4));
                }
            }
            else
            {
                for (int i = 0; i < (n - 3) / 2; i++)
                {
                    Console.WriteLine("|{0}{1}{0}|",
                        new string('-', n - 1),
                        new string('#', n * 4));
                }
            }

            spaces = 2;
            lines = 1;
            dashes = n * 6 - 6;

            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine("{0}{1}{2}{3}",
                    new string(' ', spaces),
                    new string('/', lines),
                    new string('-', dashes),
                    new string('\\', lines));

                lines++;
                dashes -= 6;
                spaces += 2;
            }
        }
    }
}
