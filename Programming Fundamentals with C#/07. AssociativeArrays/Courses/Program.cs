using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (command != "end")
            {
                string[] cmdArg = command.Split(" : ");
                string courseName = cmdArg[0];
                string studentName = cmdArg[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);

                command = Console.ReadLine();
            }

            foreach (var currentCourses in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{currentCourses.Key}: {currentCourses.Value.Count}");

                foreach (var item in currentCourses.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
