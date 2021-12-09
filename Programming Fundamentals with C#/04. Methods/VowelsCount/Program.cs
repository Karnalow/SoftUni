using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            CountVowels(input);
        }

        public static void CountVowels(string input)
        {
            int couter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (letter == 'a' || letter == 'A')
                {
                    couter++;
                }
                else if (letter == 'o' || letter == 'O')
                {
                    couter++;
                }
                else if (letter == 'e' || letter == 'E')
                {
                    couter++;
                }
                else if (letter == 'u' || letter == 'U')
                {
                    couter++;
                }
                else if (letter == 'i' || letter == 'I')
                {
                    couter++;
                }
                else if (letter == 'y' || letter == 'Y')
                {
                    couter++;
                }
            }

            Console.WriteLine(couter);
        }
    }
}
