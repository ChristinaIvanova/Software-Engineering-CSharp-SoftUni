using System;
using System.Linq;

namespace E06_Bomb_the_Basement
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

            var matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            var bomb = Console.ReadLine()
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            BombedArray(rows, cols, matrix, bomb);

            FinalBasement(cols, matrix);

            Print(matrix);
        }

        private static void FinalBasement(int cols, int[][] matrix)
        {
            for (int col = 0; col < cols; col++)
            {
                var currentCol = GetColumn(matrix, col);
                var countBombedCells = currentCol.Where(x => x == 1).Count();

                if (countBombedCells > 0)
                {
                    ClearColumn(matrix, col);

                    for (int i = 0; i < countBombedCells; i++)
                    {
                        matrix[i][col] = 1;
                    }
                }
            }
        }

        private static void BombedArray(int rows, int cols, int[][] matrix, int[] bomb)
        {
            var bombRow = bomb[0];
            var bombCol = bomb[1];
            var radius = bomb[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    bool isInRadius = Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2) <=
                        Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }
        }

        private static int[] GetColumn(int[][] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x][columnNumber])
                    .ToArray();
        }
        private static void ClearColumn(int[][] matrix, int columnNumber)
        {

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][columnNumber] = 0;
            }
        }
        
        private static void Print(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
     
    }


}
