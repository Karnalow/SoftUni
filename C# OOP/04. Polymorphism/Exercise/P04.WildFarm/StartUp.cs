using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P04.WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] animalInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Animal> animals = new List<Animal>();

            while (animalInfo[0] != "End")
            {
                Animal animal = CreateAnimal(animalInfo);

                animals.Add(animal);

                string[] foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.MakeSound());

                if (!animal.PreferredFoods.Contains(food.GetType()))
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                }
                else
                {
                    animal.Feed(food);
                }

                animalInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodInfo)
        {
            Food food = null;

            string foodType = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);

            if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal = null;

            string animalType = animalInfo[0];
            string animalName = animalInfo[1];
            double animalWeight = double.Parse(animalInfo[2]);

            if (animalInfo.Length == 5)
            {
                string animalLivingRegion = animalInfo[3];
                string animaBreed = animalInfo[4];

                if (animalType == "Cat")
                {
                    animal = new Cat(animalName, animalWeight, animalLivingRegion, animaBreed);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(animalName, animalWeight, animalLivingRegion, animaBreed);
                }
            }
            else if (animalInfo.Length == 4)
            {
                if (double.TryParse(animalInfo[3], out double animalWingSize))
                {
                    if (animalType == "Owl")
                    {
                        animal = new Owl(animalName, animalWeight, animalWingSize);
                    }
                    else if (animalType == "Hen")
                    {
                        animal = new Hen(animalName, animalWeight, animalWingSize);
                    }
                }
                else
                {
                    string livingRegion = animalInfo[3];

                    if (animalType == "Dog")
                    {
                        animal = new Dog(animalName, animalWeight, livingRegion);
                    }
                    else if (animalType == "Mouse")
                    {
                        animal = new Mouse(animalName, animalWeight, livingRegion);
                    }
                }
            }

            return animal;
        }
    }
}
