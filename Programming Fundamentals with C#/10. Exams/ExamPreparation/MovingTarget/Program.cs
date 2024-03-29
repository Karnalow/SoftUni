﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (cmdArg[0] != "End")
            {
                string command = cmdArg[0];
                int index = int.Parse(cmdArg[1]);
                int value = int.Parse(cmdArg[2]);

                if (index < 0 || index >= targets.Count)
                {
                    if (command == "Add")
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else if (command == "Strike")
                    {
                        Console.WriteLine("Strike missed!");
                    }

                    continue;
                }

                if (command == "Shoot")
                {
                    targets[index] -= value;

                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                if (command == "Add")
                {
                    targets.Insert(index, value);
                }
                if (command == "Strike")
                {
                    if (index - value < 0 || index + value >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");

                        continue;
                    }

                    for (int i = index - value; i <= index + value; i++)
                    {
                        targets.RemoveAt(index - value);
                    }
                }

                cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
