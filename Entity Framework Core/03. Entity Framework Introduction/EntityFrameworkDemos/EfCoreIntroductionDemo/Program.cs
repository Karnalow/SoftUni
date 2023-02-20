using EfCoreIntroductionDemo.Model;
using System;
using System.Linq;

namespace EfCoreIntroductionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new PersonContext();

            int numberOfPersons = db.Persons.Count();
            int numberOfStudents = db.Students.Count();

            var teachers = db.Teachers.Select(x => x.Name).OrderBy(x => x).ToList();
            var numberOfTeachers = db.Teachers.Count();

            Console.WriteLine($"Number of teachers: {numberOfTeachers}");

            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }
    }
}
