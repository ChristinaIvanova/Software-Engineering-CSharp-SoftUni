using System;
using System.Linq;
using System.Collections.Generic;

namespace E03_Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            var numbers = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                switch (command)
                {
                    case "1":
                        var numberToAdd = int.Parse(input[1]);
                        numbers.Push(numberToAdd);
                        break;
                    case "2":
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case "3":
                        if (numbers.Any())
                        {
                            var maximumElement = numbers.Max();
                            Console.WriteLine(maximumElement);
                        }
                        break;
                    case "4":
                        if (numbers.Any())
                        {
                            var minimum = numbers.Min();
                            Console.WriteLine(minimum);
                        }
                        break;
                }
            }

            var finalQuery = string.Join(", ", numbers);
            Console.WriteLine(finalQuery);
        }
    }
}
