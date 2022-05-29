using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P04.MergeFiles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using StreamReader inputFile1 = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P04.MergeFiles\Data\Input1.txt");

            using StreamReader inputFile2 = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P04.MergeFiles\Data\Input2.txt");

            using StreamWriter outputFile = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P04.MergeFiles\Data\Output.txt");

            List<int> result = new List<int>();

            while (!inputFile1.EndOfStream && !inputFile2.EndOfStream)
            {
                int numberFromFile1 = int.Parse(inputFile1.ReadLine());
                int numberFromFile2 = int.Parse(inputFile2.ReadLine());

                result.Add(numberFromFile1);
                result.Add(numberFromFile2);
            }

            foreach (var number in result.OrderBy(x => x))
            {
                outputFile.WriteLine(number);
            }
        }
    }
}
