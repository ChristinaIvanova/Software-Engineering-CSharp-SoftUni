﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace E01_Basic_stack_operations
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            var numbersToRemove = input[1];
            var numberToLookFor = input[2];

            var numbersToAdd = Console.ReadLine().Split()
                .Select(int.Parse);

            var numbers = new Stack<int>(numbersToAdd);

            if (numbers.Count >= numbersToRemove)
            {
                for (int i = 0; i < numbersToRemove; i++)
                {
                    numbers.Pop();
                }
            }

            if (numbers.Contains(numberToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                var smallestNumber = 0;

                if (numbers.Any())
                {
                    smallestNumber = numbers.Min();
                }
     
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
