using P04.WildFarm.Models.Animals.Contracts;
using P04.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal, IFeedable, ISoundProducable
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightIncreaser { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightIncreaser;
        }

        public abstract string MakeSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
