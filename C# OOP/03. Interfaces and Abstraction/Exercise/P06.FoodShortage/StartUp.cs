﻿using P06.FoodShortage.Contracts;
using P06.FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
