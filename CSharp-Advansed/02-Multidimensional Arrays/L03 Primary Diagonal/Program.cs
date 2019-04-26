using System;
using System.Linq;

namespace L03_Primary_Diagonal
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, rows];

            var sumPrimaryDiagonal = 0;

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

            for (int row = 0; row < rows; row++)
            {
                sumPrimaryDiagonal += matrix[row, row];
            }

            Console.WriteLine(sumPrimaryDiagonal);
        }
    }
}
