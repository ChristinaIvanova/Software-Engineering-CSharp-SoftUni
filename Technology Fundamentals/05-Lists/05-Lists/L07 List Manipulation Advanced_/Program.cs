using System;
using System.Linq;
using System.Collections.Generic;

namespace L07_List_Manipulation_Advanced_
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            string originalNumbers = string.Join(" ", numbers);
            List<int> changedNumbrers = Command(numbers);
            string newList = string.Join(" ",changedNumbrers);
            if (newList != originalNumbers)
            {
                Console.WriteLine(string.Join(" ", changedNumbrers));
            }

        }

        private static List<int> Command(List<int> numbers)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int removeNumber = int.Parse(tokens[1]);
                        numbers.Remove(removeNumber);
                        break;
                    case "RemoveAt":
                        int removePosition = int.Parse(tokens[1]);
                        numbers.RemoveAt(1);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                    default:
                        break;
                }
                switch (tokens[0])
                {
                    case "Contains":
                        int availableNumber = int.Parse(tokens[1]);
                        if (numbers.Contains(availableNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(number => number % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(number => number % 2 != 0)));
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        int secondCondition = int.Parse(tokens[2]);
                        switch (tokens[1])
                        {
                            case "<":
                                Console.WriteLine(string.Join(" ", numbers.Where(number => number < secondCondition))); break;
                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(number => number > secondCondition))); break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(number => number <= secondCondition))); break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(number => number >= secondCondition))); break;
                        }
                        break;
                }
            }
            return numbers;
        }
    }
}
