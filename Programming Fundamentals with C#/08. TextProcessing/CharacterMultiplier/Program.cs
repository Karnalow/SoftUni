using System;
using System.Linq;

namespace CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstWord = input[0];
            string secondWord = input[1];

            string shortestWord = secondWord;
            string longestWord = firstWord;

            if (longestWord.Length < secondWord.Length)
            {
                longestWord = secondWord;
                shortestWord = firstWord;
            }

            int total = Sum(longestWord, shortestWord);

            Console.WriteLine(total);
        }

        static int Sum(string longestWord, string shortestWord)
        {
            int sum = 0;

            for (int i = 0; i < shortestWord.Length; i++)
            {
                int multyply = longestWord[i] * shortestWord[i];
                sum += multyply;
            }

            for (int i = shortestWord.Length; i < longestWord.Length; i++)
            {
                sum += longestWord[i];
            }

            return sum;
        }
    }
}
