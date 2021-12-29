using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PreferredFoods => new List<Type>()
        {
            typeof(Meat)
        };

        public override double WeightIncreaser => 0.25;

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
    }
}
