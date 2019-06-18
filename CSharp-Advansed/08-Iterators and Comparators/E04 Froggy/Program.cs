namespace E04Froggy
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var stoneValues = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stoneValues);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
