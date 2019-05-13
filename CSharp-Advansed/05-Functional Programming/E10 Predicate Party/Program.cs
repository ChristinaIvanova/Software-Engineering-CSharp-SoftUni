using System;
using System.Linq;
using System.Collections.Generic;

namespace E10_Predicate_Party
{
    class Program
    {
        static void Main()
        {
            var guests = Console.ReadLine()
                .Split()
                .ToList();

            var input = Console.ReadLine();

            var filtered = new List<string>();

            Func<string, string, bool> startsWith = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWith = (a, b) => a.EndsWith(b);
            Func<string, string, bool> length = (a, b) => a.Length == int.Parse(b);

            while (input != "Party!")
            {
                var tokens = input.Split();
                var command = tokens[0];
                var filterCommand = tokens[1];
                var criteria = tokens[2];

                switch (filterCommand)
                {
                    case "StartsWith":
                        filtered = guests.Where(g => startsWith(g, criteria)).ToList();
                        break;
                    case "EndsWith":
                        filtered = guests.Where(g => endsWith(g, criteria)).ToList();
                        break;
                    case "Length":
                        filtered = guests.Where(g => length(g, criteria)).ToList();
                        break;
                }

                switch (command)
                {
                    case "Remove":
                        guests = guests.Where(g => !filtered.Contains(g)).ToList();
                        break;
                    case "Double":
                        foreach (var name in filtered)
                        {
                            var index = guests.IndexOf(name);
                            guests.Insert(index + 1, name);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
