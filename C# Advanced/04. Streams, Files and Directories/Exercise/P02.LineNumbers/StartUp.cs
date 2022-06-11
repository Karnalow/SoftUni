using System;
using System.IO;
using System.Linq;

namespace P02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P02.LineNumbers\Data\text.txt");
            using StreamWriter sw = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P02.LineNumbers\Data\output.txt");

            char[] symbolsForReplace = { '-', ',', '.', '!', '?' };

            string line = string.Empty;
            int counter = 1;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                int numberOfLetters = line.Count(char.IsLetter);
                int numberOfPunctuationMarks = line.Count(char.IsPunctuation);

                string formatedLine = $"Line {counter}: {line} ({numberOfLetters})({numberOfPunctuationMarks})";
                sw.WriteLine(formatedLine);

                counter++;
            }
        }
    }
}
