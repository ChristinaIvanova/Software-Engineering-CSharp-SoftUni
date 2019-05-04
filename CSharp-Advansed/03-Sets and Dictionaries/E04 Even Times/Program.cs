using System;
using System.Linq;
using System.Collections.Generic;

namespace E04_Even_Times
{
    class Program
    {
        static void Main()
        {
            var numbers = new Dictionary<int, int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }

                numbers[number]++;
            }

            var repeatedEvenTimes = numbers.FirstOrDefault(x => x.Value % 2 == 0);
            Console.WriteLine($"{repeatedEvenTimes.Key}");
        }
    }
}
