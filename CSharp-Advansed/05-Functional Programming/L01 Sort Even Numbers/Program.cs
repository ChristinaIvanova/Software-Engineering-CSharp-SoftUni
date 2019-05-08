using System;
using System.Linq;

namespace L01_Sort_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                 .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .Where(x => x % 2 == 0)
                 .OrderBy(x => x);

            var result = string.Join(", ", numbers);
            Console.WriteLine(result);
        }
    }
}
