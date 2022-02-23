using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.GameObjects
{
    public class FoodHash : Food
    {
        private const char HashSymbol = '#';
        private const int HashPoints = 3;

        public FoodHash(Wall wall) 
            : base(wall, HashSymbol, HashPoints)
        {
        }
    }
}
