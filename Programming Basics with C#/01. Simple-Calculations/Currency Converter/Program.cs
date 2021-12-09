using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("suma=");
            var sum = double.Parse(Console.ReadLine());
            var cue1 = Console.ReadLine().ToUpper();
            var cur2 = Console.ReadLine().ToUpper();
            if (cue1 == "BGN")
            {
                if (cur2 == "USD")
                {
                    Console.WriteLine(Math.Round(sum / 1.79549,2) + "USD");
                }
                else if (cur2 == "EUR")
                {
                    Console.WriteLine(Math.Round(sum / 1.95583,2) + "EUR");
                }
                else if (cur2 == "GBP")
                {
                    Console.WriteLine(Math.Round(sum / 2.53405,2) + "GBP");
                }
            }
            if (cue1 == "USD")
            {
               if (cur2 == "BGN")
               {
                   Console.WriteLine(Math.Round(sum * 1.79549,2) + "BGN");
               }
               else if (cur2 == "EUR")
               {
                   Console.WriteLine(Math.Round(sum * 1.79549/ 1.95583,2) + "EUR");
               }
               else if (cur2 == "GBP")
               {
                    Console.WriteLine(Math.Round(sum * 1.79549 / 2.53405, 2) + "GBP");
               }
            }
            if (cue1 == "GBP")
            {
                if (cur2 == "BGN")
                {
                    Console.WriteLine(Math.Round(sum * 2.53405,2) + "BGN");
                }
                else if (cur2 == "USD")
                {
                    Console.WriteLine(Math.Round(sum * 2.53405 / 1.79549,2) + "USD");
                }
                else if (cur2 == "EUR")
                {
                    Console.WriteLine(Math.Round(sum * 2.53405 / 1.95583, 2) + "EUR");
                }
            }
            if (cue1 == "EUR")
            {
                if (cur2 == "BGN")
                {
                    Console.WriteLine(Math.Round(sum * 1.95583, 2) + "BGN");
                }
                else if (cur2 == "USD")
                {
                    Console.WriteLine(Math.Round(sum * 1.95583 / 1.79549, 2) + "USD");
                }
                else if (cur2 == "GBP")
                {
                    Console.WriteLine(Math.Round(sum * 1.95583 / 2.53405,2) + "GBP");
                }
            }
        }
    }
}