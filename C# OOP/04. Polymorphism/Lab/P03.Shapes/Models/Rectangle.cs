using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Shapes.Models
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }



        public override double CalculateArea()
        {
            double area =  this.Height * this.Width;

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = (2 * this.Height) + (2 * this.Width);

            return perimeter;
        }

        public override string Draw()
        {
            return $"Rectangle area: {CalculateArea():f2}\n" +
                   $"Rectangle perimeter: {CalculatePerimeter():f2}";
        }
    }
}
