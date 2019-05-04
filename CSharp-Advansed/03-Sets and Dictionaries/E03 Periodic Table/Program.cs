using System;
using System.Linq;
using System.Collections.Generic;

namespace E03_Periodic_Table
{
    class Program
    {
        static void Main()
        {
            var compounds = new SortedSet<string>();
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < line.Length; j++)
                {
                    var compound = line[j];
                    compounds.Add(compound);
                }
            }

            var compounsInString = string.Join(" ", compounds);
            Console.WriteLine(compounsInString);
        }
    }
}
