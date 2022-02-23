using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.InitalizeWall();
        }

        private void InitalizeWall()
        {
            this.InitalizeHorizontal(0);
            this.InitalizeHorizontal(this.TopY);

            this.InitalizeVertical(0);
            this.InitalizeVertical(this.LeftX);
        }

        private void InitalizeVertical(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(0, topY, WallSymbol);
            }

            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(this.LeftX, topY, WallSymbol);
            }
        }

        private void InitalizeHorizontal(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, 0, WallSymbol);
            }

            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, this.TopY, WallSymbol);
            }
        }
    }
}
