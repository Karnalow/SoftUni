using System;
using System.Linq;
using System.IO;

namespace P01.EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P01.EvenLines\Data\text.txt");
            using StreamWriter sw = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P01.EvenLines\Data\output.txt");

            char[] symbolsForReplace = { '-', ',', '.', '!', '?' };

            int counter = 0;

            string line = string.Empty;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                if (counter % 2 == 0)
                {
                    foreach (var symbol in symbolsForReplace)
                    {
                        line = line.Replace(symbol, '@');
                    }

                    string[] reversedLine = line.Split(' ');

                    sw.WriteLine(string.Join(' ', reversedLine.Reverse()));
                }

                counter++;
            }
        }
    }
}
