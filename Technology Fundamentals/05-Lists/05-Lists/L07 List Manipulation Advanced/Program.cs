using System;
using System.Linq;
using System.Collections.Generic;

namespace L07_List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            string originalList=string.Join(" ",numbers);
            List<int> changedNumbers = Commands(numbers);
            if (changedNumbers != numbers)
            {
                Console.WriteLine(string.Join(" ", changedNumbers));
            }
            else
            {
                Console.WriteLine();
            }

        }

        private static List<int> Commands(List<int> numbers)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();

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
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x < secondCondition))); break;
                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x > secondCondition))); break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x <= secondCondition))); break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x >= secondCondition))); break;
                        }
                        break;
                }
            }
        }



    }
}
