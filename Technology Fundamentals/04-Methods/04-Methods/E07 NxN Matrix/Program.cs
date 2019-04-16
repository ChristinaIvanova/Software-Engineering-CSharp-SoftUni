using System;

namespace E07_NxN_Matrix
{
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            PrintMatrix(matrixSize);
        }

        private static void PrintMatrix(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixSize;

                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
