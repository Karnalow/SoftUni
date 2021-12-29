using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PreferredFoods => new List<Type>()
        { 
            typeof(Vegetable),
            typeof(Meat)
        };

        public override double WeightIncreaser => 0.30;

        public override string MakeSound()
        {
            return "Meow";
        }
    }
}
