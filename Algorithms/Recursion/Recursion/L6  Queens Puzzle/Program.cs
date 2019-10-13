using System;
using System.Collections.Generic;

namespace L6__Queens_Puzzle
{
    class Program
    {
        private const int Size = 8;
        static int[,] chessboard = new int[Size, Size];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void Solve(int row)
        {
            if (row == Size)
            {
                PrintSolution();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlace(row, col))
                    {
                        MarkAttackedFields(row, col);
                        Solve(row + 1);
                        UnmarkAttackedFields(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessboard[row, col] == 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void UnmarkAttackedFields(int row, int col)
        {
            chessboard[row, col] = 0;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAttackedFields(int row, int col)
        {
            chessboard[row, col] = 1;
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlace(int row, int col)
        {
            if (attackedRows.Contains(row))
            {
                return false;
            }

            if (attackedCols.Contains(col))
            {
                return false;
            }

            //left up
            for (int i = 1; i < Size; i++)
            {
                var currentRow = row - i;
                var currentCol = col - i;

                if (currentRow < 0 || currentRow >= Size
                                   || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (chessboard[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            //right up
            for (int i = 1; i < Size; i++)
            {
                var currentRow = row - i;
                var currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size
                                   || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (chessboard[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            //right down
            for (int i = 1; i < Size; i++)
            {
                var currentRow = row + i;
                var currentCol = col + i;

                if (currentRow < 0 || currentRow >= Size
                                   || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (chessboard[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            //left down
            for (int i = 1; i < Size; i++)
            {
                var currentRow = row + i;
                var currentCol = col - i;

                if (currentRow < 0 || currentRow >= Size
                                   || currentCol < 0 || currentCol >= Size)
                {
                    break;
                }

                if (chessboard[currentRow, currentCol] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Solve(0);
        }
    }
}
