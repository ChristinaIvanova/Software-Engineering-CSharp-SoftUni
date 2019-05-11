using System;
using System.Linq;
using System.Collections.Generic;

namespace E06_Reverse_and_Exclude
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> include = x => x % divisor != 0;

            numbers = numbers.Reverse().Where(include);
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}