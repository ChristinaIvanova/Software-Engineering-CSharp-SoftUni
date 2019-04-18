using System;

namespace ME02_Centre_point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            string centerPoint=CenterPoint(x1, y1, x2, y2);
            Console.WriteLine(centerPoint);
        }

        private static string CenterPoint(double x1, double y1, double x2, double y2)
        {
            double distanceFirstPoint = Math.Abs(x1) + Math.Abs(y1);
            double distanceSecondPoint = Math.Abs(x2) + Math.Abs(y2);

            if (distanceSecondPoint < distanceFirstPoint)
            {
                return $"({x2}, {y2})";
            }
            else
            {
                return $"({x1}, {y1})";
            }
        }
    }
}
