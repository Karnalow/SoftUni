using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grade);
            }

            foreach (var student in students.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50)
                                            .OrderByDescending(x => x.Value.Sum() / x.Value.Count))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Sum() / student.Value.Count():f2}");
            }
        }
    }
}
