using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using StreamReader wordsFile = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P03.WordCount\Data\words.txt");

            using StreamReader inputFile = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P03.WordCount\Data\Input.txt");

            using StreamWriter outputFile = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P03.WordCount\Data\Output.txt");

            Dictionary<string, int> result = new Dictionary<string, int>();

            char[] delimiterChars = { ' ', ',', '.', '?', '-', '!' };

            string inputWords = wordsFile.ReadToEnd().ToLower();
            string[] words = inputWords.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            string line = inputFile.ReadToEnd().ToLower();
            string[] wordsInLine = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                result.Add(word, 0);

                foreach (var wordInLine in wordsInLine)
                {
                    if (word == wordInLine)
                    {
                        result[word]++;
                    }
                }
            }

            foreach (var word in result.OrderByDescending(x => x.Value))
            {
                outputFile.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
