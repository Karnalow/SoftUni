using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> ordered = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split().ToArray();

                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name, age);

                if (person.Age > 30)
                {
                    ordered.Add(person);
                }
            }

            List<Person> orderedPeople = ordered.OrderBy(x => x.Name).ToList();

            Console.WriteLine(string.Join(Environment.NewLine , orderedPeople));
        }
    }
}
