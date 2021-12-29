using P04.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Animals.Contracts
{
    public interface IFeedable
    {
        int FoodEaten { get; }

        ICollection<Type> PreferredFoods { get; }

        void Feed(IFood food);
    }
}
