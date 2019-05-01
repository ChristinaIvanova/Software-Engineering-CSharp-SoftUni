using System;
using System.Linq;
using System.Collections.Generic;

namespace E05_Snake_Moves
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            char[][] jagged = new char[rows][];

            var snakeStr = Console.ReadLine().ToCharArray();

            Queue<char> snakeQueue = new Queue<char>(snakeStr);

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = new char[cols];

                for (int col = 0; col < cols; col++)
                {
                    char charToAdd = snakeQueue.Dequeue();
                    jagged[row][col] = charToAdd;
                    snakeQueue.Enqueue(charToAdd);
                }
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
