using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                string name = command[0];
                string iD = command[1];
                int age = int.Parse(command[2]);

                Person person = new Person(name, iD, age);

                people.Add(person);

                command = Console.ReadLine().Split();
            }

            foreach (Person person in people.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
