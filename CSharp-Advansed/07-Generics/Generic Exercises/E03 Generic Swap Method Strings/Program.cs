namespace E03_Generic_Swap_Method_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine();
                box.Add(line);
            }

            var indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            box.Swap(firstIndex, secondIndex);

           // Swap(box.Values, firstIndex, secondIndex);

            Console.WriteLine(box);
        }

        static void Swap<T>(List<T> listWithValues, int firstIndex, int secondIndex)
        {
            var temp = listWithValues[firstIndex];
            listWithValues[firstIndex] = listWithValues[secondIndex];
            listWithValues[secondIndex] = temp;
        }
    }
}
