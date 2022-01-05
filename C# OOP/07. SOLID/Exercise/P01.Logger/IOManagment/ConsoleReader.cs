using P01.Logger.IOManagment.Contracts;
using System;

namespace P01.Logger.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
