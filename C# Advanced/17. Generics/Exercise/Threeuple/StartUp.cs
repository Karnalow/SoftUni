using System;
using System.Collections.Generic;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] namesOfPeople = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = namesOfPeople[0];
            string lastName = namesOfPeople[1];
            string street = namesOfPeople[2];
            string town = string.Empty;

            if (namesOfPeople.Length == 4)
            {
                town = namesOfPeople[3];
            }
            else if (namesOfPeople.Length > 4)
            {
                List<string> list = new List<string>(namesOfPeople);

                list.RemoveRange(0, 3);

                town = string.Join(' ', list);
            }

            string[] drunkInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = drunkInfo[0];
            int liters = int.Parse(drunkInfo[1]);
            string drunkOrNot = drunkInfo[2];

            if (drunkOrNot == "drunk")
            {
                drunkOrNot = "True";
            }
            else if (drunkOrNot == "not")
            {
                drunkOrNot = "False";
            }

            string[] bankInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string nameForBank = bankInfo[0];
            double balance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            Threeuple<string, string, string> informationAboutPerson =
            new Threeuple<string, string, string>($"{firstName} {lastName}", street, town);

            Threeuple<string, int, string> personDrunkOrNot =
            new Threeuple<string, int, string>(name, liters, drunkOrNot);

            Threeuple<string, double, string> personBankInfo =
            new Threeuple<string, double, string>(nameForBank, balance, bankName);

            Console.WriteLine(informationAboutPerson.GetItems());
            Console.WriteLine(personDrunkOrNot.GetItems());
            Console.WriteLine(personBankInfo.GetItems());
        }
    }
}
