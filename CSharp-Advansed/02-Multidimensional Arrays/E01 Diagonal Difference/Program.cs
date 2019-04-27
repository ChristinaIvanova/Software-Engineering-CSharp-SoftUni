using System;
using System.Linq;

namespace E01_Diagonal_Difference
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var matrix = new int[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var primarySum = PrimaryDiagonalSum(rows, matrix);
            var secondarySum = SecondaryDiagonalSum(rows, matrix);

            var difference = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(difference);
        }

        private static int PrimaryDiagonalSum(int rows, int[,] matrix)
        {
            var sum = 0;
            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, row];
            }
            return sum;
        }

        private static int SecondaryDiagonalSum(int rows, int[,] matrix)
        {
            var sum = 0;
            var col = rows - 1;

            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, col];
                col--;
            }
            return sum;
        }
    }
}
