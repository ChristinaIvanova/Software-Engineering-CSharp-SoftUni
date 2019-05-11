using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_Custom_Comparator
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (a, b) =>
            (a % 2 == 0 && b % 2 != 0) ? -1 :
            (a % 2 != 0 && b % 2 == 0) ? 1 :
            a.CompareTo(b);
            
            Array.Sort(numbers, new Comparison<int>(sortFunc));
     
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
