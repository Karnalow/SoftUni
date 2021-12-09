using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> towns =
                new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Sail")
            {
                string town = input[0];
                int people = int.Parse(input[1]);
                double gold = double.Parse(input[2]);

                if (towns.ContainsKey(town))
                {
                    gold += gold;
                    people += people;


                    towns[town]["people"] = people;
                    towns[town]["gold"] = gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, double>());

                    towns[town]["people"] = people;
                    towns[town]["gold"] = gold;
                }

                input = Console.ReadLine()
                .Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] text = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (text[0] != "End")
            {
                string cmdArg = text[0];
                string town = text[1];

                if (cmdArg == "Plunder")
                {
                    int people = int.Parse(text[2]);
                    double gold = double.Parse(text[3]);

                    if (towns[town]["people"] >= people && towns[town]["gold"] >= gold) 
                    {
                        towns[town]["people"] -= people;
                        towns[town]["gold"] -= gold;

                        Console.WriteLine
                            ($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                    if (towns[town]["people"] <= 0 || towns[town]["gold"] <= 0)
                    {
                        towns.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (cmdArg == "Prosper")
                {
                    double gold = double.Parse(text[2]);

                    if (towns.ContainsKey(town))
                    {
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            towns[town]["gold"] += gold;

                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town]["gold"]} gold.");
                        }
                    }
                }

                text = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

            foreach (var town in towns.OrderByDescending(g => g.Value["gold"]).ThenBy(g => g.Key))
            {
                Console.WriteLine($"{town.Key} -> Population: {town.Value["people"]} citizens, Gold: {town.Value["gold"]} kg");
            }
        }
    }
}
