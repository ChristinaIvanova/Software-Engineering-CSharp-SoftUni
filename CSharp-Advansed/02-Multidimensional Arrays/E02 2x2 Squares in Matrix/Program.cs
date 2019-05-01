using System;
using System.Linq;

namespace E02_2x2_Squares_in_Matrix
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
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int counterPairs = SquareOfEqualChars(rows, cols, matrix);

            Console.WriteLine(counterPairs);
        }

        private static int SquareOfEqualChars(int rows, int cols, char[,] matrix)
        {
            var counterPairs = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counterPairs++;
                    }
                }
            }

            return counterPairs;
        }
    }
}
