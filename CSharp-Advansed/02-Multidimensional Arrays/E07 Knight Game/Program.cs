using System;
using System.Linq;

namespace E07_Knight_Game
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] board = new char[n][];

            for (int i = 0; i < board.Length; i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                board[i] = new char[n];
                board[i] = inputRow;
            }

            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = 0;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < board[rowIndex].Length; colIndex++)
                    {
                        if (board[rowIndex][colIndex].Equals('K'))
                        {
                            // vertical up and left
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex - 2, colIndex - 1);

                            // vertical up and right
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex - 2, colIndex + 1);

                            // vertical down and left
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex + 2, colIndex - 1);
                           
                            // vertical down and right
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex + 2, colIndex + 1);
                           
                            // horizontal up and left
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex - 1, colIndex - 2);
                           
                            // horizontal up and right
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex - 1, colIndex + 2);
                            
                            // horizontal down and left
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex + 1, colIndex - 2);
                            
                            // horizontal down and right
                            currentKnightsInDanger += CountKnightsInDanger(board, rowIndex + 1, colIndex + 2);
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = rowIndex;
                            mostDangerousKnightCol = colIndex;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    board[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        private static int CountKnightsInDanger(char[][] matrix, int row, int col)
        {
            var counKnights = 0;

            if (IsCellInMatrix(row, col, matrix))
            {
                if (matrix[row][col].Equals('K'))
                {
                    counKnights++;
                }
            }

            return counKnights;
        }

        public static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}
