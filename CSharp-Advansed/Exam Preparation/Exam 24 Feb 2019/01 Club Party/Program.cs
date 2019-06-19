using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Club_Party
{

    class Program
    {
        static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var elements = new Stack<string>(input);
            var halls = new Queue<string>();
            var allGroups = new List<int>();

            var currentCapacity = 0;

            while (elements.Count > 0)
            {
                var current = elements.Pop();

                var isNumeric = int.TryParse(current, out int people);

                if (!isNumeric)
                {
                    halls.Enqueue(current);
                }
                else if (isNumeric && halls.Any())
                {
                    if (currentCapacity + people > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Any())
                    {
                        allGroups.Add(people);
                        currentCapacity += people;
                    }
                }
            }
        }
    }
}
