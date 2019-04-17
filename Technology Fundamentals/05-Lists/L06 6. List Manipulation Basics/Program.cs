using System;
using System.Linq;
using System.Collections.Generic;

namespace L06_6._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
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
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
