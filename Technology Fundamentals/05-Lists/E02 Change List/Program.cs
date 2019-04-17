using System;
using System.Linq;
using System.Collections.Generic;

namespace E02_Change_List
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            List<int> changedNumbers = ChangedList(numbers);
            Console.WriteLine(string.Join(" ", changedNumbers));
        }

        private static List<int> ChangedList(List<int> numbers)
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
                    case "Delete":
                        //for (int i = 0; i < numbers.Count; i++)
                        //{
                        //   numbers.Remove(int.Parse(tokens[1])); 
                        //}
                        int removeValue = int.Parse(tokens[1]);
                        numbers.RemoveAll(n => n == removeValue);
                        break; 
                    case "Insert":
                        int newValue = int.Parse(tokens[1]);
                        int position = int.Parse(tokens[2]);
                        numbers.Insert(position, newValue);
                        break;
                    default:
                        break;
                }
            }
            return numbers;
        }
    }
}
