using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string[] command = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                string action = command[0];

                try
                {
                    if (action == "Team")
                    {
                        string teamName = command[1];

                        Team team = new Team(teamName);

                        teams.Add(teamName, team);
                    }
                    else if (action == "Add")
                    {
                        string teamName = command[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");

                            command = Console.ReadLine()
                            .Split(';', StringSplitOptions.RemoveEmptyEntries);

                            continue;
                        }

                        string playerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int drible = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);

                        Player player = new Player(playerName, endurance, sprint, drible, passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        string teamName = command[1];
                        string playerName = command[2];

                        teams[teamName].RemovePlayer(playerName);
                    }
                    else if (action == "Rating")
                    {
                        string teamName = command[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");

                            command = Console.ReadLine()
                            .Split(';', StringSplitOptions.RemoveEmptyEntries);

                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
