using System;
using System.Linq;

namespace ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string currentSimbol = input[i];

                if (IsValid(currentSimbol))
                {
                    Console.WriteLine(currentSimbol);
                }
            }
        }

        public static bool IsValid(string currentSimbol)
        {
            return currentSimbol.Length >= 3 &&
                currentSimbol.Length <= 16 &&
                currentSimbol.All(c => char.IsLetterOrDigit(c)) ||
                currentSimbol.Contains("-") ||
                currentSimbol.Contains("_");
        }
    }
}
