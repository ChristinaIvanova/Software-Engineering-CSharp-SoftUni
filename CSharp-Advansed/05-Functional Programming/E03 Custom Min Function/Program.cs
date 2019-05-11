using System;
using System.Collections.Generic;
using System.Linq;

namespace E03_Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            
            Func<List<int>, int> findMin = x => x.Min();

            Console.WriteLine(findMin(numbers));
        }
    }
}
