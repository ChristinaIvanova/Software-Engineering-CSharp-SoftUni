using System;
using System.Linq;

namespace L02PointInRectangle
{
  public  class Startup
    {
        static void Main()
        {
            var coordinatesRectangle = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var topLeft = new Point(coordinatesRectangle[0], coordinatesRectangle[1]);
            var bottomRight = new Point(coordinatesRectangle[2], coordinatesRectangle[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var pointArgs= Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                var pointToCheck = new Point(pointArgs[0], pointArgs[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }
        }
    }
}
