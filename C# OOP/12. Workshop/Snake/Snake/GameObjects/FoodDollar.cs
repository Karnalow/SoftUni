using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char Dollar = '$';
        private const int DollarPoints = 2;

        public FoodDollar(Wall wall) 
            : base(wall, Dollar, DollarPoints)
        {
        }
    }
}
