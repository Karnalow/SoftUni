using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var word in text)
            {
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 1);
                }
                else if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }

            }

            var removeEmptySpaces = counts.Where(a => a.Key != ' ');

            foreach (var word in removeEmptySpaces)
            {
                Console.WriteLine($"{word.Key} -> {word.Value}");
            }
        }
    }
}
