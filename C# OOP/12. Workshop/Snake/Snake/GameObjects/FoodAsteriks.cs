using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.GameObjects
{
    public class FoodAsteriks : Food
    {
        private const char AsteriksSymbol = '*';
        private const int AsteriksPoints = 1;

        public FoodAsteriks(Wall wall) 
            : base(wall, AsteriksSymbol, AsteriksPoints)
        {
        }
    }
}
