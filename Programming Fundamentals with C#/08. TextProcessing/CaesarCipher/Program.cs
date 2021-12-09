using System;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                int movedLeter = letter + 3;

                output += (char)(movedLeter);
            }

            Console.WriteLine(output);
        }
    }
}
