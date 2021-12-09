using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(";");
            string[] productsInput = Console.ReadLine().Split(";");

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (var name in names)
            {
                string[] input = name.Split("=");

                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }
            foreach (var product in productsInput)
            {
                string[] input = product.Split("=");

                if (input.Length > 1)
                {
                    Product product1 = new Product(input[0], int.Parse(input[1]));
                    products.Add(product1);
                }
            }

            string[] command = Console.ReadLine().Split(); 

            while (command[0] != "END")
            {
                string name = command[0];
                string product = command[1];

                Person findPerson = people.FirstOrDefault(x => x.Name == name);
                Product findProduct = products.FirstOrDefault(x => x.Name == product);

                if (findPerson.Money >= findProduct.Cost)
                {
                    findPerson.Money -= findProduct.Cost;

                    findPerson.AddProduct(findProduct);

                    Console.WriteLine($"{name} bought {product}");
                }
                else
                {
                    Console.WriteLine($"{name} can't afford {product}");
                }

                command = Console.ReadLine().Split();
            }

            foreach (var person in people)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> BagOfProducts { get; set; }

        public void AddProduct(Product product)
        {
            this.BagOfProducts.Add(product);
        }
    }

    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
