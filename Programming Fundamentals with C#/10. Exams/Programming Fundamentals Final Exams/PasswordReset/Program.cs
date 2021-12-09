using System;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Done")
            {
                string cmdArg = command[0];

                if (cmdArg == "TakeOdd")
                {
                    string temp = string.Empty;

                    for (int i = 0; i < output.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            temp += output[i];
                        }
                    }

                    output = temp;

                    Console.WriteLine(output);
                }
                else if (cmdArg == "Cut")
                {
                    int index = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    output = output.Remove(index, length);

                    Console.WriteLine(output);
                }
                else if (cmdArg == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (output.Contains(substring))
                    {
                        output = output.Replace(substring, substitute);

                        Console.WriteLine(output);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your password is: {output}");
        }
    }
}
