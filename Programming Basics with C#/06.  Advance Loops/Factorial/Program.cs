﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = 1;
            for (int i = 2; i <= n; i++)
                result = result * i;
            Console.WriteLine(result);
        }
    }
}
