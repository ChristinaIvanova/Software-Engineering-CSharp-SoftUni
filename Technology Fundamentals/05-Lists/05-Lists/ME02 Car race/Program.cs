using System;
using System.Linq;
using System.Collections.Generic;
namespace ME02_Car_race
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> firstRacer = new List<int>();
            List<int> secondRacer = new List<int>();
            double sumTimeFirst = CalculateLeftTime(numbers, firstRacer);
            double sumTimeSecond = CalculatedRightTime(numbers, secondRacer);
            double winningTime = Math.Min(sumTimeFirst, sumTimeSecond);
            string winner = FindWinner(sumTimeFirst, sumTimeSecond, winningTime);
            Console.WriteLine($"The winner is {winner} with total time: {winningTime}");
        }

        private static double CalculateLeftTime(List<int> numbers, List<int>LeftRacer)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                LeftRacer.Add(numbers[i]);
                sum += numbers[i];
                if (numbers[i] == 0)
                {
                    sum *= 0.8;
                }
            }
            return sum;
        }

        private static double CalculatedRightTime(List<int> numbers, List<int> RightRacer)
        {
            double sum = 0;
            for (int i = numbers.Count-1; i > numbers.Count / 2; i--)
            {
                RightRacer.Add(numbers[i]);
                sum += numbers[i];
                if (numbers[i] == 0)
                {
                    sum *= 0.8;
                }
            }
            return sum;
        }

        private static string FindWinner(double sumTimeFirst, double sumTimeSecond, double winningTime)
        {
            string winner = string.Empty;
            if (winningTime == sumTimeFirst)
            {
                winner = "left";
            }
            else
            {
                winner = "right";
            }
            return winner;
        }
    }
}
