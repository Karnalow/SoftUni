using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length % 2 == 0);

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
