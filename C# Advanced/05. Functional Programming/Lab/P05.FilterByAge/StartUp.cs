using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FilterByAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> persons = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                persons.Add(name, age);
            }

            string condition = Console.ReadLine();
            int ageBorder = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (format == "name")
            {
                if (condition == "older")
                {
                    foreach (var person in persons.Where(p => p.Value >= ageBorder))
                    {
                        Console.WriteLine(person.Key);
                    }
                }
                else if (condition == "younger")
                {
                    foreach (var person in persons.Where(p => p.Value < ageBorder))
                    {
                        Console.WriteLine(person.Key);
                    }
                }
            }
            else if (format == "age")
            {
                if (condition == "older")
                {
                    foreach (var person in persons.Where(p => p.Value >= ageBorder))
                    {
                        Console.WriteLine(person.Value);
                    }
                }
                else if (condition == "younger")
                {
                    foreach (var person in persons.Where(p => p.Value < ageBorder))
                    {
                        Console.WriteLine(person.Value);
                    }
                }
            }
            else if (format == "name age")
            {
                if (condition == "older")
                {
                    foreach (var person in persons.Where(p => p.Value >= ageBorder))
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
                else if (condition == "younger")
                {
                    foreach (var person in persons.Where(p => p.Value < ageBorder))
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
            }
        }
    }
}
