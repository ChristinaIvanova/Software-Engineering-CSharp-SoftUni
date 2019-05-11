using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            var rangeArea = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var start = rangeArea[0];
            var end = rangeArea[1];

            var typeNumbers = Console.ReadLine();

            var numbers = new List<int>();

            Predicate<int> filter = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;

            for (int number = start; number <= end; number++)
            {
                numbers.Add(number);
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));
        }
    }
}
