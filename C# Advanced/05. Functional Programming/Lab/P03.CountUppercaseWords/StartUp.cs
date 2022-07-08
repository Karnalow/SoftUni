using System;
using System.Linq;

namespace P03.CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] symbols = new char[] { ' ', '.', '!', '?', ',', ':', ';'};

            string[] text = Console.ReadLine()
                .Split(symbols, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> upperCaseFirstLetter = word => char.IsUpper(word[0]);

            var upperWordsLetter = text.Where(upperCaseFirstLetter);

            foreach (var word in upperWordsLetter)
            {
                Console.WriteLine(word);
            }
        }
    }
}
