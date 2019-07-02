using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            Galaxy galaxy = new Galaxy(rows, cols);
            galaxy.CreateStars();

            long sumOfStars = 0;

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                galaxy.ClearStars(evilCoordinates);
                sumOfStars += galaxy.SelectStars(playerCoordinates);

                command = Console.ReadLine();
            }

            Console.WriteLine(sumOfStars);
        }
    }
}
