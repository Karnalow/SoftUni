using System;
using System.IO;

namespace P05.SliceFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream("sliceMe.txt", FileMode.OpenOrCreate);

            byte[] data = new byte[fileStream.Length];

            var bytesPerFile = (int)Math.Ceiling(fileStream.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                byte[] buffer = new byte[bytesPerFile];
                fileStream.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
        }
    }
}
