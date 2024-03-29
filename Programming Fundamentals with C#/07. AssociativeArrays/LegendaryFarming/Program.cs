﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMatirial = new Dictionary<string, int>();
            Dictionary<string, int> junkMatirial = new Dictionary<string, int>();

            keyMatirial["shards"] = 0;
            keyMatirial["motes"] = 0;
            keyMatirial["fragments"] = 0;

            bool hasToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string matirial = input[i + 1].ToLower();

                    if (matirial == "shards" || matirial == "motes" || matirial == "fragments")
                    {
                        keyMatirial[matirial] += quantity;

                        if (keyMatirial[matirial] >= 250)
                        {
                            keyMatirial[matirial] -= 250;

                            if (matirial == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (matirial == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (matirial == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            hasToBreak = true;

                            break;
                        }
                    }
                    else
                    {
                        if (!junkMatirial.ContainsKey(matirial))
                        {
                            junkMatirial.Add(matirial, 0);
                        }

                        junkMatirial[matirial] += quantity;
                    }
                }

                if (hasToBreak == true)
                {
                    break;
                }
            }

            Dictionary<string, int> filteredKeyMatirials = keyMatirial
                .OrderByDescending(v => v.Value)
                .ThenBy(k => k.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var kvp in filteredKeyMatirials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMatirial.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
