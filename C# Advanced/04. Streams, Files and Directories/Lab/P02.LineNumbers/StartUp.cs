using System;
using System.IO;

namespace P02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P02.LineNumbers\Data\Input.txt");

            StreamWriter sw = new StreamWriter(@"D:\Repositories\SoftUni\C# Advanced\04. Streams, Files and Directories\Lab\P02.LineNumbers\Data\Output.txt");

            string line = sr.ReadLine();
            int counter = 1;

            while (line != null)
            {
                sw.WriteLine($"{counter}.{line}");

                counter++;
                line = sr.ReadLine();
            }

            sw.Close();
            sr.Close();
        }
    }
}
