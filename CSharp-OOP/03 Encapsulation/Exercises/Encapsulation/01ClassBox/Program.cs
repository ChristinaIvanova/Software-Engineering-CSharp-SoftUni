using System;

namespace _01ClassBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (ArgumentException msg)
            {
                Console.WriteLine(msg.Message);
            }

        }
    }
}
