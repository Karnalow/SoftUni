using P04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PreferredFoods => new List<Type>()
        {
            typeof(Meat)
        };

        public override double WeightIncreaser => 0.40;

        public override string MakeSound()
        {
            return "Woof!";
        }
    }
}
