using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = "Pesho";
            int age = 20;

            Person person = new Person(name, age);

            Console.WriteLine($"{person.Name} {person.Age}");

            name = "Gosho";
            age = 18;

            Person secondPerson = new Person(name, age);

            Console.WriteLine($"{secondPerson.Name} {secondPerson.Age}");

            name = "Stamat";
            age = 43;

            Person thirdPerson = new Person(name, age);

            Console.WriteLine($"{thirdPerson.Name} {thirdPerson.Age}");
        }
    }
}
