using System;
using System.Collections.Generic;
using System.Linq;

namespace L05_Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main()
        {
            //List<int> numbers = Console.ReadLine().Split()
            //    .Select(int.Parse).ToList();
            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbers[i] < 0)
            //    {
            //        numbers.Remove(numbers[i]);
            //        i = -1;
            //    }
            //}
            //if (numbers.Count > 0)
            //{
            //    numbers.Reverse();
            //    Console.WriteLine(string.Join(" ",numbers));
            //}
            //else
            //{
            //    Console.WriteLine("empty");
            //}
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            List<int> positiveNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    positiveNumbers.Add(numbers[i]);
                }
            }
            if (positiveNumbers.Count > 0)
            {
                positiveNumbers.Reverse();
                Console.WriteLine(string.Join(" ", positiveNumbers));
            }
            else
            {
                Console.WriteLine("empty");
            }

        }
    }
}
