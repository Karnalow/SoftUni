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
            string resultFilePath = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P03.WordCount\Data\actualResult.txt";
            string expectedResultFilePath = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P03.WordCount\Data\expectedResult.txt";
            string textFilePath = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P03.WordCount\Data\text.txt";
            string wordsFilePath = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P03.WordCount\Data\words.txt";

            using StreamReader textFile = new StreamReader(textFilePath);

            using StreamReader wordsFile = new StreamReader(wordsFilePath);

            using StreamReader expectedResultFile = new StreamReader(expectedResultFilePath);

            using StreamWriter resultFile = new StreamWriter(resultFilePath);

            Dictionary<string, int> result = new Dictionary<string, int>();

            char[] delimiterChars = { ' ', ',', '.', '?', '-', '!' };

            string inputWords = wordsFile.ReadToEnd().ToLower();
            string[] words = inputWords.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            string line = textFile.ReadToEnd().ToLower();
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
                resultFile.WriteLine($"{word.Key} - {word.Value}");
            }

            //bool areEquals = File.ReadLines(resultFilePath).SequenceEqual(File.ReadLines(expectedResultFilePath));

            //Console.WriteLine(areEquals);
        }
    }
}
