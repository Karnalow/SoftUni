using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = double.Parse(Console.ReadLine());
            var w = double.Parse(Console.ReadLine());
            if (3 <= w && w <= l && l<=100)
            {
                l *= 100;
                w *= 100;
                var rows = (int)l / 120;
                var deskOnRow = ((int)w - 100) / 70;
                var places = (rows * deskOnRow) - 3;
                Console.WriteLine(places);
            }
            else
                Console.WriteLine("Error");
        }
    }
}
