using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingValidation = new Dictionary<string, string>();

            int parkingCapacity = int.Parse(Console.ReadLine());

            for (int i = 0; i < parkingCapacity; i++)
            {
                string[] input =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string stat = input[0];
                string name = input[1];

                if (stat == "register")
                {
                    string licensePlateNumber = input[2];

                    if (parkingValidation.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        parkingValidation.Add(name, licensePlateNumber);

                        Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
                    }
                }
                else if (stat == "unregister")
                {
                    if (parkingValidation.ContainsKey(name))
                    {
                        parkingValidation.Remove(name);

                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }

            foreach (var person in parkingValidation)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }
        }
    }
}
