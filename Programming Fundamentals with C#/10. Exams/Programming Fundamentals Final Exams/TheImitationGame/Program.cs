using System;
using System.Linq;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Decode")
            {
                string cmdArg = command[0];

                if (cmdArg == "Move")
                {
                    int numberOfLetters = int.Parse(command[1]);

                    string letters = message.Substring(0, numberOfLetters);

                    message = message.Remove(0, numberOfLetters);
                    message = message.Insert(message.Length, letters);
                }
                else if (cmdArg == "Insert")
                {
                    int index = int.Parse(command[1]);
                    string value = command[2];

                    message = message.Insert(index, value);
                }
                else if (cmdArg == "ChangeAll")
                {
                    char substring = char.Parse(command[1]);
                    char replacement = char.Parse(command[2]);

                    foreach (var item in message)
                    {
                        if (item == substring)
                        {
                            message = message.Replace(substring, replacement);
                        }
                    }
                }

                command = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
