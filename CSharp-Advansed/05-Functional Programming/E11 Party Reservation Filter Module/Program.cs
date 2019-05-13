using System;
using System.Linq;
using System.Collections.Generic;

namespace E11_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string, bool> startsWith = (a, b) => a.StartsWith(b);
            Func<string, string, bool> endsWith = (a, b) => a.EndsWith(b);
            Func<string, string, bool> lenght = (a, b) => a.Length == int.Parse(b);
            Func<string, string, bool> contains = (a, b) => a.Contains(b);

            var filteredNames = new List<string>();
            var reservations = new List<string>(names);

            while (true)
            {
                var input = Console.ReadLine();

                if (input=="Print")
                {
                    names.RemoveAll(n => !reservations.Contains(n));
                    var result = string.Join(" ", names);
                    Console.WriteLine(result);
                    break;
                }

                var tokens=input                   
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var filterType = tokens[1];
                var criteria = tokens[2];

                switch (filterType)
                {
                    case "Starts with":
                        filteredNames = names.Where(n => startsWith(n, criteria)).ToList();
                        break;
                    case "Ends with":
                        filteredNames = names.Where(n => endsWith(n, criteria)).ToList();
                        break;
                    case "Length":
                        filteredNames = names.Where(n => lenght(n, criteria)).ToList();
                        break;
                    case "Contains":
                        filteredNames = names.Where(n => contains(n, criteria)).ToList();
                        break;
                }

                switch (command)
                {
                    case "Add filter":
                        reservations.RemoveAll(n => filteredNames.Contains(n));
                        break;
                    case "Remove filter":
                        reservations.AddRange(filteredNames);
                        break;
                }
            } 
        }
    }
}
