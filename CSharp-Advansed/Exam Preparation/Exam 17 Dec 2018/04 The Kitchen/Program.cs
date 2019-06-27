using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_The_Kitchen
{
    class Program
    {
        static void Main()
        {
            var knivesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var forksInput = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse);

            var knives = new Stack<int>(knivesInput);
            var forks = new Queue<int>(forksInput);

            var readyPairs = new List<int>();

            while (knives.Any() && forks.Any())
            {
                var currentKnife = knives.Pop();
                var currentFork = forks.Peek();

                if (currentKnife > currentFork)
                {
                    forks.Dequeue();
                    readyPairs.Add(currentKnife + currentFork);
                }
                else if (currentKnife == currentFork)
                {
                    forks.Dequeue();
                    knives.Push(currentKnife + 1);
                }
            }

            var biggestSet = readyPairs.Max();
            var pairs = string.Join(" ", readyPairs);

            Console.WriteLine($"The biggest set is: {biggestSet}");
            Console.WriteLine(pairs);
        }
    }
}
