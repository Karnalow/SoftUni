using System;

namespace P05.ConvertToDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int a = Convert.ToInt32(userInput[0]);
            int b = Convert.ToInt32(userInput[1]);
            int c = Convert.ToInt32(userInput[2]);
            int d = Convert.ToInt32(userInput[3]);
            int e = Convert.ToInt32(userInput[4]);

            int sumOfAll = a + b + c + d + e;

            Console.WriteLine(sumOfAll);
        }
    }
}
