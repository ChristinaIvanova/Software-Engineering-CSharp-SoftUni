using System;
using System.Collections.Generic;
using System.Linq;

namespace E12_Inferno_III
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<int> active = Enumerable.Range(0, numbers.Count).ToList();
            List<int> current = new List<int>(active);

            Func<int, int, bool> sumLeft = (a, b) =>
            a == 0 ? numbers[a] == b : numbers[a] + numbers[a - 1] == b;

            Func<int, int, bool> sumRight = (a, b) =>
            a == numbers.Count - 1 ? numbers[a] == b : numbers[a] + numbers[a + 1] == b;

            Func<int, int, bool> sumLeftRight = (a, b) =>
            numbers.Count == 1 ? numbers[0] == b
            : a == 0 ? numbers[a] + numbers[a + 1] == b
            : a == numbers.Count - 1 ? numbers[a] + numbers[a - 1] == b
            : numbers[a] + numbers[a - 1] + numbers[a + 1] == b;

            var input = Console.ReadLine();

            while (input != "Forge")
            {
                var filtered = new List<int>();

                var tokens = input
                    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var filterType = tokens[1];
                var criteria = int.Parse(tokens[2]);

                switch (filterType)
                {
                    case "Sum Left":
                        filtered = current.Where(i => sumLeft(i, criteria)).ToList();
                        break;
                    case "Sum Right":
                        filtered = current.Where(i => sumRight(i, criteria)).ToList();
                        break;
                    case "Sum Left Right":
                        filtered = current.Where(i => sumLeftRight(i, criteria)).ToList();
                        break;
                }

                switch (command)
                {
                    case "Exclude":
                        active.RemoveAll(i => filtered.Contains(i));
                        break;
                    case "Reverse":
                        active.AddRange(filtered);
                        break;
                }

                input = Console.ReadLine();
            }

            var result = string.Join
                       (" ", numbers.Where((n, index) => active.Contains(index)));
            Console.WriteLine(result);
        }
    }
}
