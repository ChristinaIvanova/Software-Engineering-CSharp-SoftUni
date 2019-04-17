using System;
using System.Linq;
using System.Collections.Generic;

namespace L03_Merging_Lists
{
    class Program
    {
        static void Main()
        {
            List<int> firstList = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            List<int> result = new List<int>();
            int minCount = Math.Min(firstList.Count, secondList.Count);
            List<int> biggerList;
            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }

            if (minCount==firstList.Count)
            {
                biggerList = secondList;
            }
            else
            {
                biggerList = firstList;
            }
            for (int i = minCount; i < biggerList.Count; i++)
            {
                result.Add(biggerList[i]);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
