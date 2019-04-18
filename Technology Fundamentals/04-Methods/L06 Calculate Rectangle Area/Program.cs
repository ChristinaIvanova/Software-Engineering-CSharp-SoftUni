using System;

namespace L06_Calculate_Rectangle_Area
{
    class Program
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double heigh = double.Parse(Console.ReadLine());

            double area=GetRectangleArea(width,heigh);
            Console.WriteLine(area);
        }

        private static double GetRectangleArea(double width, double heigh)
        {
            return width * heigh;
        }
    }
}
