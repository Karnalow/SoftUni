﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle_with_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('%', n*2));
            var numRows = n - 1;
            if (n % 2 == 1) numRows++;
            for (int i = 0; i < numRows; i++)
            {
                Console.Write("%");
                Console.Write(new string(' ', n - 2));
                if (i == (n - 1) / 2)
                    Console.Write("**");
                else
                    Console.Write("  ");
                Console.Write(new string(' ', n - 2));
                Console.Write("%");
                Console.WriteLine();
            }
            Console.WriteLine(new string('%', n * 2));

        }
    }
}
