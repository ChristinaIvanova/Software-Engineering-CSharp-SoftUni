using System;
using System.Linq;
using System.Collections.Generic;

namespace L01_Count_Same_Values_in_Array
{
    class Program
    {
        static void Main()
        {
            var numbers = new Dictionary<double, int>();

            var input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                var number = double.Parse(input[i]);

                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }

                numbers[number]++;
            }

            foreach (var kvp in numbers)
            {
                var number = kvp.Key;
                var counter = kvp.Value;

                Console.WriteLine($"{number} - {counter} times");
            }
        }
    }
}
