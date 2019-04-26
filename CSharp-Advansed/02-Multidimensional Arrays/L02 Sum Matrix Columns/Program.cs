using System;
using System.Linq;

namespace L02_Sum_Matrix_Columns
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var currentRow= Console.ReadLine()
                .Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int col = 0; col < columns; col++)
            {
                var sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
