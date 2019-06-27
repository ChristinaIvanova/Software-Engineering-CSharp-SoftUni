using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Sport_Cards
{
    class Program
    {
        static void Main()
        {
            var sportCardsInfo = new Dictionary<string, Dictionary<string, double>>();

            var input = Console.ReadLine();

            while (input != "end")
            {
                if (input.Split(" ").Length != 2)
                {
                    var commandArgs = input
                       .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                    var cardName = commandArgs[0];
                    var sport = commandArgs[1];
                    var price = double.Parse(commandArgs[2]);

                    if (!sportCardsInfo.ContainsKey(cardName))
                    {
                        sportCardsInfo[cardName] = new Dictionary<string, double>();
                    }

                    sportCardsInfo[cardName][sport] = price;
                }
                else
                {
                    var commandArgs = input
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var cardName = commandArgs[1];

                    if (sportCardsInfo.ContainsKey(cardName))
                    {
                        Console.WriteLine($"{cardName} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{cardName} is not available!");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in sportCardsInfo
                .OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}:");

                Console.WriteLine(string.Join
                    (Environment.NewLine, kvp.Value.OrderBy(x => x.Key)
                    .Select(s => $" -{s.Key} - {s.Value:f2}")));
            }
        }
    }
}
