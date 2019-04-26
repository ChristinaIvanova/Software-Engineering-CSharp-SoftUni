using System;
using System.Linq;

namespace L04_Symbol_in_Matrix
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();
                char[] currentRowToArray = currentRow.ToArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = currentRowToArray[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());

            bool isFound = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (matrix[row, col] == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        return;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix ");
            }
        }
    }
}
