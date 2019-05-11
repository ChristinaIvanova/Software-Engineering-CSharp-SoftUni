using System;
using System.Linq;
using System.Collections.Generic;

namespace E07_Predicate_for_Names
{
    class Program
    {
        static void Main()
        {

            var lenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split();

            Predicate<string> filter = x => x.Length <= lenght;

            names
                .Where(x => filter(x))
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }
}
