
using System;
using System.Linq;
 
namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] bugsField = new int[fieldSize];

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < 0 || indexes[i] >= fieldSize)
                {
                    continue;
                }
                bugsField[indexes[i]] = 1;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();

                string command = tokens[1];
                int startIndex = int.Parse(tokens[0]);
                int targetIndex = 0;

                bool isCommandValid = startIndex >= 0 && startIndex < fieldSize && bugsField[startIndex] == 1;
                if (!isCommandValid)
                {
                    continue;
                }
                bugsField[startIndex] = 0;
                int bug = 1;
                int direction = 0;
                if (command == "right")
                {
                    targetIndex = startIndex + int.Parse(tokens[2]);
                    direction += int.Parse(tokens[2]);
                }
                else
                {
                    targetIndex = startIndex - int.Parse(tokens[2]);
                    direction -= int.Parse(tokens[2]);
                }
                while (bug == 1 && targetIndex >= 0 && targetIndex < fieldSize)
                {
                    if (bugsField[targetIndex] == 0)
                    {
                        bugsField[targetIndex] = 1;
                        bug = 0;
                    }
                    targetIndex += direction;
                }
            }
            Console.WriteLine(string.Join(' ', bugsField));
        }
    }
}