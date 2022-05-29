using System;
using System.IO;

namespace P01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P01.OddLines\Data\input.txt");

            using StreamWriter sw = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P01.OddLines\Data\output.txt");

            string line = sr.ReadLine();
            int counter = 0;

            while (line != null)
            {
                if (counter % 2 != 0)
                {
                    sw.WriteLine(line);
                }

                counter++;
                line = sr.ReadLine();
            }
        }
    }
}
