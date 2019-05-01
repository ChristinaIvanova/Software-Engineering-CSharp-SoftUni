using System;
using System.Linq;

namespace E03_Maximum_Sum
{
    class Program
    {
        static void Main()
        {
            var dimension = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimension[0];
            var cols = dimension[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var maxSum = int.MinValue;
            var maxRowIndex = 0;
            var maxColIndex = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row+1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxRowIndex, maxColIndex]} {matrix[maxRowIndex, maxColIndex + 1]} {matrix[maxRowIndex, maxColIndex + 2]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1, maxColIndex]} {matrix[maxRowIndex + 1, maxColIndex + 1]} {matrix[maxRowIndex + 1, maxColIndex + 2]}");
            Console.WriteLine($"{matrix[maxRowIndex + 2, maxColIndex]} {matrix[maxRowIndex + 2, maxColIndex + 1]} {matrix[maxRowIndex + 2, maxColIndex + 2]}");
        }
    }
}
