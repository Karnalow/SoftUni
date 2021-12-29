using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PreferredFoods => new List<Type>()
        {
            typeof(Fruit),
            typeof(Vegetable)
        };

        public override double WeightIncreaser => 0.10;

        public override string MakeSound()
        {
            return "Squeak";
        }
    }
}
