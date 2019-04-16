using System;
using System.Linq;
using System.Collections.Generic;

namespace E04_List_Operations
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split();
                ExecuteCommands(numbers, tokens);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ExecuteCommands(List<int> numbers, string[] tokens)
        {

            switch (tokens[0])
            {
                case "Add":
                    numbers.Add(int.Parse(tokens[1]));
                    break;
                case "Insert":
                    int insertNum = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    if (indexToInsert >= 0 && indexToInsert < numbers.Count)
                    {
                        numbers.Insert(indexToInsert, insertNum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Remove":
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;
                case "Shift":
                    string direction = tokens[1];
                    int count = int.Parse(tokens[2]);
                    ShiftList(numbers, direction, count);
                    break;
                default:
                    break;
            }
        }

        private static void ShiftList(List<int> numbers, string direction, int count)
        {
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int first = numbers[0];
                    //for (int j = 0; j < numbers.Count - 1; j++)
                    //{
                    //    numbers[j] = numbers[j + 1];
                    //}
                    //numbers[numbers.Count - 1] = first;
                    numbers.Add(first);
                    numbers.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);

                }
            }
        }
    }
}
