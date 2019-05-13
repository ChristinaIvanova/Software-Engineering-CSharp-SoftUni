using System;
using System.Collections.Generic;
using System.Linq;

namespace E09_List_of_Predicates
{
    class Program
    {
        static void Main()
        {
            var endOfRange = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var divisibleNumbers = GetDivisibleNumbers(endOfRange, divisors);

            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }

        private static List<int> GetDivisibleNumbers(int endOfRange, List<int> divisors)
        {
            var divisibleNumbers = new List<int>();

            for (int number = 1; number <= endOfRange; number++)
            {
                var isDivisible = true;

                foreach (var divisor in divisors)
                {
                    Predicate<int> isNotDivisor = x => number % x != 0;

                    if (isNotDivisor(divisor))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    divisibleNumbers.Add(number);
                }
            }

            return divisibleNumbers;
        }
    }
}
