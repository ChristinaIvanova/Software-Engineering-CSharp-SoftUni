using System;
using System.Linq;
using System.Collections.Generic;

namespace E03_Periodic_Table
{
    class Program
    {
        static void Main()
        {
            var elements = new SortedSet<string>();
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < line.Length; j++)
                {
                    var compound = line[j];
                    elements.Add(compound);
                }
            }

            var uniqueElements = string.Join(" ", elements);
            Console.WriteLine(uniqueElements);
        }
    }
}
