using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PreferredFoods => new List<Type>()
        { 
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
            typeof(Vegetable)
        };

        public override double WeightIncreaser => 0.35;

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
