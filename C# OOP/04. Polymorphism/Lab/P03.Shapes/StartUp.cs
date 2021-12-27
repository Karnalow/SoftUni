using P03.Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            Circle circle = new Circle(radius);

            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(height, width);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
