using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] peopleInfo = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < peopleInfo.Length; i++)
                {
                    string[] currentPersonInfo = peopleInfo[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = currentPersonInfo[0];
                    double money = double.Parse(currentPersonInfo[1]);

                    Person person = new Person(name, money);

                    people[name] = person;
                }

                string[] productInfo = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInfo.Length; i++)
                {
                    string[] currentProductInfo = peopleInfo[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = currentProductInfo[0];
                    double cost = double.Parse(currentProductInfo[1]);

                    Product product = new Product(name, cost);

                    products[name] = product;
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] cmdArg = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string name = cmdArg[0];
                    string product = cmdArg[1];
                    double personMoney = people[name].Money;
                    double cost = products[product].Cost;

                    if (personMoney - cost < 0)
                    {
                        Console.WriteLine($"{name} can't afford {product}");
                    }
                    else
                    {
                        people[name].Money -= cost;
                        Console.WriteLine($"{name} bought {product}");
                        people[name].Bag.Add(product);
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

                return;
            }

            foreach (var person in people)
            {
                Console.Write($"{person.Key} - ");
                if (person.Value.Bag.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", person.Value.Bag));
                }
            }
        }
    }
}
