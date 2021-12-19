using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());

                box.AddMethod(element);
            }

            double value = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountMethodString(value));
        }
    }
}
