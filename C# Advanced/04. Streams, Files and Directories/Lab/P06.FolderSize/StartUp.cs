using System;
using System.IO;

namespace P06.FolderSize
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using StreamWriter sr = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P06.FolderSize\Output.txt");

            string directoryPath = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P06.FolderSize\TestFolder";

            string[] files = Directory.GetFiles(directoryPath);

            long totalLenght = 0;

            foreach (string file in files)
            {
                totalLenght += new FileInfo(file).Length;
            }

            sr.Write(totalLenght);
        }
    }
}
