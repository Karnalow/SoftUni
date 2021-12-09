using System;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> ranking = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] cmdArg = command.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArg[0];
                string password = cmdArg[1];

                ranking[contest] = new List<string>();
                ranking[contest].Add(password);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] cmdArg = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArg[0];
                string password = cmdArg[1];
                string username = cmdArg[2];
                int points = int.Parse(cmdArg[3]);

                users[username] = new List<int>();

                foreach (var rank in ranking)
                {
                    if (rank.Key.Contains(contest))
                    {
                        if (rank.Value.Contains(password))
                        {
                            users[username].Add(points);
                        }
                    }
                    if (rank.Key.Contains(contest))
                    {
                        foreach (var user in users)
                        {
                            if (user.Key.Contains(username))
                            {
                                if (true)
                                {

                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
