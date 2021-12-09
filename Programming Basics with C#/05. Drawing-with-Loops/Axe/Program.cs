using System;

namespace Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var width = 5 * n;
            var leftDashes = 3 * n;
            var middleDashes = 0;
            var rightDashes = width - leftDashes - middleDashes - 2;
            for (int i = 0; i < i + n; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));
                middleDashes--;
                rightDashes++;
            }
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('-', leftDashes), new string('-', middleDashes), new string('-', rightDashes));
            }
        }
    }
}
