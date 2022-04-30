using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrades
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> people = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];
                double grade = double.Parse(line[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new List<double>());
                    people[name].Add(grade);
                }
                else
                {
                    people[name].Add(grade);
                }
            }

            foreach (var person in people)
            {
                double avarageGrade = person.Value.Sum() / person.Value.Count();

                Console.WriteLine($"{person.Key} -> " +
                    $"{string.Join(' ', person.Value.Select(x => Math.Round(x, 2)))} " +
                    $"(avg: {avarageGrade:f2})");
            }
        }
    }
}
