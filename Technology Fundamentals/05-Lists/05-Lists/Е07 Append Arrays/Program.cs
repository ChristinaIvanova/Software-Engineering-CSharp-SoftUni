using System;
using System.Linq;
using System.Collections.Generic;

namespace Е07_Append_Arrays
{
    class Program
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();
            List<int> finalList = new List<int>();
            foreach (var number in numbers)
            {
                finalList.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList()
                    );
            }
            Console.WriteLine(string.Join(" ",finalList));
        }
    }
}
