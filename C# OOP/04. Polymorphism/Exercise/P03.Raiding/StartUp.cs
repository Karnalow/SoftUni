using P03.Raiding.Models;
using System;
using System.Collections.Generic;

namespace P03.Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<BaseHero> heros = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heros.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = null;

                if (heroType == "Druid")
                {
                    hero = new Druid(heroName);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
                if (hero != null)
                {
                    heros.Add(hero);
                }
            }

            int sumOfPowers = 0;

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());

                sumOfPowers += hero.Power;
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (bossPower <= sumOfPowers)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
