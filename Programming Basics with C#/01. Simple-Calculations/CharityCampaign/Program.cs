using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Броят на дните, в които тече кампанията:");
            var days = int.Parse(Console.ReadLine());
            Console.Write("Броят на сладкарите:");
            var people = int.Parse(Console.ReadLine());
            Console.Write("Броят на тортите:");
            var cakes = int.Parse(Console.ReadLine());
            Console.Write("Броят на гофретите:");
            var waffles = int.Parse(Console.ReadLine());
            Console.Write("Броят на палачинките:");
            var panecakes = int.Parse(Console.ReadLine());
            var cakesprice = cakes * 45;
            var wafflesprice = waffles * 5.80;
            var panecakesprice = panecakes * 3.20;
            var OneDaySum = (cakesprice + wafflesprice + panecakesprice) * people;
            var CampainSum = OneDaySum * days;
            var ClearSum = CampainSum - 0.125 * CampainSum;
            if (days>0 && days<=365 && people>0 && people<=1000 && cakes>0 && cakes<=2000 && waffles > 0 && waffles <= 2000 && panecakes > 0 && panecakes <= 2000)
            {
                Console.WriteLine(Math.Round(ClearSum, 2));
            }
            else Console.WriteLine("Error");
        }
    }
}
