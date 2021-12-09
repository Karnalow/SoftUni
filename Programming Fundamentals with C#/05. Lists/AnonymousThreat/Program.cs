using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                List<string> inputRework = command.Split().ToList();

                if (inputRework[0] == "merge")
                {
                    int startIndex = int.Parse(inputRework[1]);
                    int endIndex = int.Parse(inputRework[2]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex > input.Count - 1)
                    {
                        startIndex = input.Count - 1;
                    }
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    else if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }
                    List<string> temp = new List<string>();

                    for (int i = startIndex; i <= endIndex; i++)
                    {

                        temp.Add(input[i]);
                    }

                    input[startIndex] = string.Join("", temp);

                    for (int i = startIndex + 1; i <= endIndex; i++)
                    {
                        input.RemoveAt(startIndex + 1);

                    }
                }
                else if (inputRework[0] == "divide")
                {
                    List<string> temp = new List<string>();

                    string toDivide = input[int.Parse(inputRework[1])];
                    int partitions = int.Parse(inputRework[2]);
                    int partLength = toDivide.Length / int.Parse(inputRework[2]);
                    int additionalPartLength = toDivide.Length % int.Parse(inputRework[2]);

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1) partLength += additionalPartLength;
                        temp.Add(toDivide.Substring(0, partLength));
                        toDivide = toDivide.Remove(0, partLength);
                    }

                    input.RemoveAt(int.Parse(inputRework[1]));
                    input.InsertRange(int.Parse(inputRework[1]), temp);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}