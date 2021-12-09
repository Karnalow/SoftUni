using System;

namespace ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string currentFile = input[input.Length - 1];

            string[] filteredFile = currentFile.Split('.', StringSplitOptions.RemoveEmptyEntries);

            string fileName = filteredFile[0];
            string fileExtension = filteredFile[1];

            Console.WriteLine($"File name: {fileName}\nFile extension: {fileExtension}");
        }
    }
}
