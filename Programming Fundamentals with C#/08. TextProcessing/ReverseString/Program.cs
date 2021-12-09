using System;
using System.Linq;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                string reversed = new string(line.Reverse().ToArray());

                Console.WriteLine($"{line} = {reversed}");

                line = Console.ReadLine();
            }
        }
    }
}
