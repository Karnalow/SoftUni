using System;
using System.IO;

namespace P04.CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string filerReader = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P04.CopyBinaryFile\Data\fileReader.txt";
            string filerWriter = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P04.CopyBinaryFile\Data\fileWriter.txt";

            using (FileStream reader = new FileStream(filerReader, FileMode.Open, FileAccess.Read))
            using (FileStream writer = new FileStream(filerWriter, FileMode.Create))
            {
                byte[] buffer = new byte[1024];

                int bytesRead;

                while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
