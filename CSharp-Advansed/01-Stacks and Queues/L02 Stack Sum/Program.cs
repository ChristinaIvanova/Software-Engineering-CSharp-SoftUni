using System;
using System.Linq;
using System.Collections.Generic;

namespace L02_Stack_sum
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = new Stack<int>(input);

            var commandInfo = Console.ReadLine().ToLower();

            while (commandInfo != "end")
            {
                var tokens = commandInfo.Split();
                var command = tokens[0].ToLower();

                switch (command)
                {
                    case "add":
                        var numbersToAdd = tokens.Skip(1).Take(tokens.Count() - 1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (var number in numbersToAdd)
                        {
                            numbers.Push(number);
                        }

                        break;
                    case "remove":
                        var countNumbersToRemove = int.Parse(tokens[1]);

                        if (numbers.Count > countNumbersToRemove)
                        {
                            for (int i = 0; i < countNumbersToRemove; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                }

                commandInfo = Console.ReadLine().ToLower();
            }

            var sumOfnumbers = numbers.ToList().Sum();
            Console.WriteLine($"Sum: {sumOfnumbers}");
        }
    }
}
