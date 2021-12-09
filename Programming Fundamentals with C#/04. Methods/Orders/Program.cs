using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int value = int.Parse(Console.ReadLine());

            Order(product, value);
        }

        static void Order(string product, int value)
        {
            decimal coffee = 1.50M;
            decimal water = 1.00M;
            decimal coke = 1.40M;
            decimal snacks = 2.00M;

            if (product == "coffee")
            {
                Console.WriteLine(coffee * value);
            }
            else if (product == "water")
            {
                Console.WriteLine(water * value);
            }
            else if (product == "coke")
            {
                Console.WriteLine(coke * value);
            }
            else if (product == "snacks")
            {
                Console.WriteLine(snacks * value);
            }
        }
    }
}
