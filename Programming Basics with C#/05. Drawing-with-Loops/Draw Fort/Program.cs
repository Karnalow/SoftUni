﻿using System;

namespace Draw_Fort
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var colSize = n / 2;
            var midSize = 2 * n - 2 * colSize - 4;
            Console.WriteLine("/{0}\\{1}/{0}\\", new string('^', colSize), new string('_', midSize));
            for (int row = 0; row < n - 3; row++)
            {
                Console.WriteLine("|{0}|", new string(' ', 2 * n - 2));
            }
            Console.WriteLine("|{0}{1}{0}|", new string(' ', colSize + 1), new string('_', midSize));
            Console.WriteLine("\\{0}/{1}\\{0}/", new string('_', colSize), new string(' ', midSize));
        }
    }
}
