using P01.Logger.IOManagment.Contracts;
using System;
using System.IO;

namespace P01.Logger.IOManagment
{
    public class FileWriter : IWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; }

        public void Write(string text)
        {
            File.WriteAllText(this.FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(this.FilePath, text + Environment.NewLine);
        }
    }
}
