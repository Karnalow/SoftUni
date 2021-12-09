using System;
using System.Collections.Generic;

namespace Students
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] data = Console.ReadLine().Split();

            while (data[0] != "end")
            {
                string firstName = data[0];
                string lastName = data[1];
                string age = data[2];
                string town = data[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = town;

                students.Add(student);

                data = Console.ReadLine().Split();
            }

            string selectTown = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == selectTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
