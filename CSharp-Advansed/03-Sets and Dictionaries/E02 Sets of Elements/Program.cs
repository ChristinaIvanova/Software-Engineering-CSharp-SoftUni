using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Sets_of_Elements
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = dimensions[0];
            var m = dimensions[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }

            }

            var elementsInSets = firstSet.Intersect(secondSet).ToHashSet();

            Console.WriteLine(string.Join(" ", elementsInSets));
        }
    }
}
