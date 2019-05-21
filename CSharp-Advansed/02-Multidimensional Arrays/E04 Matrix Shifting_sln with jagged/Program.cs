using System;
using System.Linq;

namespace E04_Matrix_Shifting
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
            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[row] = currentRow;
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                if (command != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                var row1 = int.Parse(tokens[1]);
                var col1 = int.Parse(tokens[2]);
                var row2 = int.Parse(tokens[3]);
                var col2 = int.Parse(tokens[4]);

                if (row1 < 0 || row1 > rows - 1 || col1 < 0 || col1 > cols - 1 ||
                    row2 < 0 || row2 > rows - 1 || col2 < 0 || col2 > cols - 1)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    var firstValue = matrix[row1][col1];
                    var secondValue = matrix[row2][col2];

                    matrix[row1][col1] = secondValue;
                    matrix[row2][col2] = firstValue;

                    PrintMatrix(rows, cols, matrix);
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(int rows, int cols, string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
