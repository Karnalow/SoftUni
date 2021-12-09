﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            var firstMetric = Console.ReadLine().ToLower();
            var secoundMetric = Console.ReadLine().ToLower();
            if (firstMetric == "mm")
                num = num / 1000;
            else if (firstMetric == "cm")
                num = num / 100;
            else if (firstMetric == "mi")
                num = num / 0.000621371192;
            else if (firstMetric == "in")
                num = num / 39.3700787;
            else if (firstMetric == "km")
                num = num / 0.001;
            else if (firstMetric == "ft")
                num = num / 3.2808399;
            else if (firstMetric == "yd")
                num = num / 1.0936133;

            if (secoundMetric == "mm")
                num = num * 1000;
            else if (secoundMetric == "cm")
                num = num * 100;
            else if (secoundMetric == "mi")
                num = num * 0.000621371192;
            else if (secoundMetric == "in")
                num = num * 39.3700787;
            else if (secoundMetric == "km")
                num = num * 0.001;
            else if (secoundMetric == "ft")
                num = num * 3.2808399;
            else if (secoundMetric == "yd")
                num = num * 1.0936133;
            Console.WriteLine(num + " " + secoundMetric);
        }
    }
}
