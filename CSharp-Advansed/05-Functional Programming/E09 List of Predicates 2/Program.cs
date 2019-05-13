using System;
using System.Linq;
using System.Collections.Generic;

namespace E09_List_of_Predicates_2
{


    class Program
    {
        static void Main()
        {
            int endRange = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .ToList();
            
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            
            dividers.ForEach(d => predicates.Add(x => x % d == 0));

            List<int> result = new List<int>();
            
            for (int i = 1; i <= endRange; i++)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);

                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}

