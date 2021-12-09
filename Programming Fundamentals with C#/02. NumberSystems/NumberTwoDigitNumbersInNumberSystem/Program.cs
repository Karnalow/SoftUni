using System;

namespace NumberTwoDigitNumbersInNumberSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int result = (input * input) - (input + 1);

            Console.WriteLine($"COUNT = {result}");
        }
    }
}
