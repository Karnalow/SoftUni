using System;
using System.IO.Compression;

namespace P05.ZipAndExtract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string path = @"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P05.ZipAndExtract\Data\photo.jfif";

            using ZipArchive zipArchive = new ZipFile.Open(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Exercise\P05.ZipAndExtract\Data\photoZip.zip", ZipArchiveMode.Create);

            zipArchive.CreateEntryFromFile(path, "photoZip.zip");
        }
    }
}
