namespace _01_action_point
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var guests = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string, bool> startsWith = (x, a) => x.StartsWith(a);
            Func<string, string, bool> endsWith = (x, a) => x.EndsWith(a);
            Func<string, string, bool> length = (x, a) => x.Length == int.Parse(a);
            Func<string, string, bool> contains = (x, a) => x.Contains(a);

            var input = Console.ReadLine();

            var listOfFilters = new List<string>();

            while (input != "Print")
            {
                var commandArgs = input.Split(";");

                var command = commandArgs[0];
                var secondCommand = commandArgs[1];
                var criteria = commandArgs[2];

                switch (command)
                {
                    case "Add filter":
                        listOfFilters.Add($"{secondCommand};{criteria}");
                        break;
                    case "Remove filter":
                        listOfFilters.Remove($"{secondCommand};{criteria}");
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var filter in listOfFilters)
            {
                var commandArgs = filter.Split(";");

                var command = commandArgs[0];
                var criteria = commandArgs[1];

                switch (command)
                {
                    case "Starts with":
                        guests.RemoveAll(g => startsWith(g, criteria));
                        break;
                    case "Ends with":
                        guests.RemoveAll(g => endsWith(g, criteria));
                        break;
                    case "Length":
                        guests.RemoveAll(g => length(g, criteria));
                        break;
                    case "Contains":
                        guests.RemoveAll(g => contains(g, criteria));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
