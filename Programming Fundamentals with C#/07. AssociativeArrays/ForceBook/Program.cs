using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "Lumpawaroo")
            {
                string forceSide;
                string forceUser;

                if (command.Contains("|"))
                {
                    string[] cmdArg = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    forceSide = cmdArg[0];
                    forceUser = cmdArg[1];

                    bool isContainsUser = false;

                    foreach (var team in force)
                    {
                        if (team.Value.Contains(forceUser))
                        {
                            isContainsUser = true;
                        }
                    }

                    if (!force.ContainsKey(forceSide))
                    {
                        force[forceSide] = new List<string>();
                    }
                    if (!isContainsUser)
                    {
                        force[forceSide].Add(forceUser);
                    }
                }
                else if (command.Contains("->"))
                {

                    string[] cmdArg = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    forceSide = cmdArg[1];
                    forceUser = cmdArg[0];

                    foreach (var team in force)
                    {
                        if (team.Value.Contains(forceUser))
                        {
                            team.Value.Remove(forceUser);
                        }
                    }

                    if (!force.ContainsKey(forceSide))
                    {
                        force[forceSide] = new List<string>();
                    }

                    force[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                command = Console.ReadLine();
            }

            foreach (var team in force.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (team.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {team.Key}, Members: {team.Value.Count}");

                    foreach (var user in team.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
