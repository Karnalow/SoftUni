using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_on_Segment
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var point = int.Parse(Console.ReadLine());
            var left = Math.Min(first, second);
            var right = Math.Max(first, second);
            var pointOnSegment = (left <= point && point <= right);
            var leftDistance = Math.Abs(point - left);
            var rightDistance = Math.Abs(point - right);
            var distance = Math.Min(leftDistance, rightDistance);
            if (pointOnSegment)
                Console.WriteLine("in");
            else
                Console.WriteLine("out");
            Console.WriteLine(distance);
        }
    }
}
