using System;

namespace ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string output = string.Empty;

            foreach (var letter in input)
            {
                if (!output.EndsWith(letter))
                {
                    output += letter;
                }
            }

            Console.WriteLine(output);
        }
    }
}
