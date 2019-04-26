using System;
using System.Linq;

namespace L06_Jagged_Array_Modification
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jagged[i] = currentRow;
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split();

                var command = tokens[0];
                var commandRow = int.Parse(tokens[1]);
                var commandCol = int.Parse(tokens[2]);
                var value = int.Parse(tokens[3]);

                if (commandRow < 0 || commandRow >= jagged.Length
                     || commandCol < 0 || commandCol >= jagged[commandRow].Length)
                {
                    Console.WriteLine($"Invalid coordinates");
                }
                else
                {
                    if (command == "Add")
                    {
                        jagged[commandRow][commandCol] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jagged[commandRow][commandCol] -= value;
                    }
                }


                input = Console.ReadLine();
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
