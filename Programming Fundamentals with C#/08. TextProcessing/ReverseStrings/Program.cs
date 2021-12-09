using System;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            foreach (var word in input)
            {
                int lenght = word.Length;

                for (int i = 0; i < lenght; i++)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
