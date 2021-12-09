using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Цена на уискито в лева:");
            var uiski = double.Parse(Console.ReadLine());
            Console.Write("Количество на бирата в литри:");
            var bira = double.Parse(Console.ReadLine());
            Console.Write("Количество на виното в литри:");
            var vino = double.Parse(Console.ReadLine());
            Console.Write("Количество на ракията в литри:");
            var rakiq = double.Parse(Console.ReadLine());
            Console.Write("Количество на уискито в литри:");
            var uiskiL = double.Parse(Console.ReadLine());
            var RakiqPrice = 0.5 * uiski;
            var VinoPrice = RakiqPrice - (0.4 * RakiqPrice);
            var BiraPrice = RakiqPrice - (0.8 * RakiqPrice);
            var sumRakiq = rakiq * RakiqPrice;
            var sumVino = vino * VinoPrice;
            var sumBira = bira * BiraPrice;
            var sumUiski = uiski * uiskiL;
            var Pesho = sumBira + sumRakiq + sumUiski + sumVino;
            if (uiski>0.00 && uiski<=10000.00 && bira > 0.00 && bira <= 10000.00 && vino > 0.00 && vino <= 10000.00 && rakiq > 0.00 && rakiq <= 10000.00 && uiskiL > 0.00 && uiskiL <= 10000.00)
            {
                Console.WriteLine(Math.Round(Pesho, 2));
            }
            else Console.WriteLine("Error");
        }
    }
}
