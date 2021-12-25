using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string doughFlourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                while (toppingInfo[0] != "END")
                {
                    string toppingType = toppingInfo[1];
                    double toppingWeight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    toppingInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
