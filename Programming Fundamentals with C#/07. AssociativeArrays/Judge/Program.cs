using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> contests = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            string[] input =
                Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "no more time")
            {
                string username = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new List<string>());

                    if (!contests[contest].Contains(username))
                    {
                        contests[contest].Add(username);
                    }
                    else
                    {
                        users[username] = users[username];
                    }
                }

                int totalPoint = 0;

                input =
                Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
