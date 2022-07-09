using System;
using System.Linq;

namespace P01.ActionPoint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> action = (x) => Console.WriteLine(x);

            strings.ToList().ForEach(x => action(x));
        }
    }
}
