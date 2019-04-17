using System;
using System.Linq;
using System.Collections.Generic;

namespace ME04_Mixed_up_Lists
{
    class Program
    {
        static void Main()
        {
            List<int> firstList = Console.ReadLine().
                Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine().
                Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();
            List<int> biggerList = new List<int>();
            int biggerCount = Math.Max(firstList.Count, secondList.Count);
            int firstConstrain;
            int secondConstrain;
            if (biggerCount==firstList.Count)
            {
                biggerList = firstList;
                firstConstrain = firstList.Count - 1;
                secondConstrain = firstList.Count - 2;
            }
            else
            {
                biggerList = secondList;
                firstConstrain = 0;
                secondConstrain = 1;
            }
            int minValue = Math.Min(biggerList[firstConstrain],
                biggerList[secondConstrain]);

            int maxValue = Math.Max(biggerList[firstConstrain],
                biggerList[secondConstrain]);
            newList.AddRange(firstList.Where(number => (number > minValue && number < maxValue)).ToList());
            newList.AddRange(secondList.Where(number => (number > minValue && number < maxValue)).ToList());
            newList.Sort();
            Console.WriteLine(string.Join(" ",newList));
        }
    }
}
