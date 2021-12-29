using P04.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get;}
    }
}
