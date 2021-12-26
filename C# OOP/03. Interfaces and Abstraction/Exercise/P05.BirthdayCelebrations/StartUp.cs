using System;
using System.Collections.Generic;

namespace P05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Citizen citizen = new Citizen();
            Pet pet = new Pet();
            Robot robot = new Robot();

            List<string> citizenCollection = new List<string>();
            List<string> petCollection = new List<string>();
            List<string> robotCollection = new List<string>();

            while (command[0] != "End")
            {
                if (command[0] == "Citizen")
                {
                    string name = command[1];
                    int age = int.Parse(command[2]);
                    string id = command[3];
                    string citizenBirthdate = command[4];

                    citizenCollection.Add(citizenBirthdate);
                }
                else if (command[0] == "Pet")
                {
                    pet.Name = command[1];
                    string petBirthdate = command[2];

                    petCollection.Add(petBirthdate);
                }
                else if (command[0] == "Robot")
                {
                    robot.Model = command[1];
                    string robotBirthdate = command[2];

                    robotCollection.Add(robotBirthdate);
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string birthdate = Console.ReadLine();

            List<string> correctDates = new List<string>();

            foreach (var correctCitizen in citizenCollection)
            {
                string substr = correctCitizen.Substring(correctCitizen.Length - 4);

                if (substr.Contains(birthdate))
                {
                    correctDates.Add(correctCitizen);
                }
            }
            foreach (var correctPet in petCollection)
            {
                string substr = correctPet.Substring(correctPet.Length - 4);

                if (substr.Contains(birthdate))
                {
                    correctDates.Add(correctPet);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, correctDates));
        }
    }
}
