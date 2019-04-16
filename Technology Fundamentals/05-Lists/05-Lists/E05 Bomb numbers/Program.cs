using System;
using System.Linq;
using System.Collections.Generic;

namespace E05_Bomb_numbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] specialNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bombNumber = specialNumbers[0];
            int power = specialNumbers[1];
           List<int> newList= RemovedBombNumbers(numbers, bombNumber, power);
            int sumOfNumbers = SumOfChangedList(numbers);
            Console.WriteLine(sumOfNumbers);
        }

        private static List<int> RemovedBombNumbers(List<int> numbers, int bombNumber, int power)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int startRemoveIndex = i - power;
                    int endRemoveIndex = i + power;
                    int countRange = 2 * power + 1;
                    if (startRemoveIndex < 0)
                    {
                        startRemoveIndex = 0;
                        countRange = i + power + 1;
                    }
                    else if (endRemoveIndex > numbers.Count)
                    {
                        countRange = power + numbers.Count - i;
                    }
                    numbers.RemoveRange(startRemoveIndex, countRange);
                    i = -1;
                }
            }
            return numbers;
        }
        private static int SumOfChangedList(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    }
}
