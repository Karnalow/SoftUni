using System;
using System.Linq;

namespace ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] cmdArg = Console.ReadLine()
            .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (cmdArg[0].ToLower() != "generate")
            {
                string command = cmdArg[0];

                if (command.ToLower() == "contains")
                {
                    string sub = cmdArg[1];

                    if (key.Contains(sub))
                    {
                        Console.WriteLine($"{key} contains {sub}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                if (command.ToLower() == "flip")
                {
                    string secondCommand = cmdArg[1];
                    int startIndex = int.Parse(cmdArg[2]);
                    int endIndex = int.Parse(cmdArg[3]);

                    string sub = key.Substring(startIndex, endIndex - startIndex);

                    if (secondCommand.ToLower() == "upper")
                    {
                        key = key.Replace(sub, sub.ToUpper());
                    }
                    else
                    {
                        key = key.Replace(sub, sub.ToLower());
                    }

                    Console.WriteLine(key);
                }
                if (command.ToLower() == "slice")
                {
                    int startIndex = int.Parse(cmdArg[1]);
                    int endIndex = int.Parse(cmdArg[2]);

                    string sub = key.Substring(startIndex, endIndex - startIndex);

                    key = key.Replace(sub, "");

                    Console.WriteLine(key);
                }

                cmdArg = Console.ReadLine()
                       .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
