using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set { radius = value; }
        }


        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(this.Radius, 2);

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override string Draw()
        {
            return $"Circle area: {CalculateArea():f2}\n" +
                   $"Circle perimeter: {CalculatePerimeter():f2}";
        }
    }
}
