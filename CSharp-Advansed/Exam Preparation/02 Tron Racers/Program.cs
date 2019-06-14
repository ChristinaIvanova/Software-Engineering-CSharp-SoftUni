using System;
using System.Linq;

namespace _02_Tron_Racers
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];

            var firstPlayerRow = 0;
            var firstPlayerCol = 0;

            var secondPlayerRow = 0;
            var secondPlayerCol = 0;

            GetMatrix(rows, matrix, ref firstPlayerRow, ref firstPlayerCol, ref secondPlayerRow, ref secondPlayerCol);

            bool isDead = false;

            while (!isDead)
            {
                var commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var firstCommand = commands[0];
                var secondCommand = commands[1];

                Movement(firstCommand, ref firstPlayerRow, ref firstPlayerCol, matrix);

                if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'x';
                    isDead = true;
                    continue;
                }

                matrix[firstPlayerRow][firstPlayerCol] = 'f';

                Movement(secondCommand, ref secondPlayerRow, ref secondPlayerCol, matrix);

                if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 'x';
                    isDead = true;
                    continue;
                }

                matrix[secondPlayerRow][secondPlayerCol] = 's';

            }
            var a = 5;

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void GetMatrix(int rows, char[][] matrix, ref int firstPlayerRow, ref int firstPlayerCol, ref int secondPlayerRow, ref int secondPlayerCol)
        {
            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                if (currentRow.Contains('f'))
                {
                    firstPlayerRow = i;
                    firstPlayerCol = Array.FindIndex(currentRow, item => item == 'f');
                }

                if (currentRow.Contains('s'))
                {
                    secondPlayerRow = i;
                    secondPlayerCol = Array.FindIndex(currentRow, item => item == 's');
                }

                matrix[i] = currentRow;
            }
        }

        private static void Movement(string command, ref int row, ref int col, char[][] matrix)
        {
            switch (command)
            {
                case "up":
                    row -= 1;
                    break;
                case "down":
                    row += 1;
                    break;
                case "left":
                    col -= 1;
                    break;
                case "right":
                    col += 1;
                    break;
            }

            bool isInMatrix = row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix.Length;

            if (!isInMatrix)
            {
                if (col < 0)
                {
                    col = matrix.Length - 1;
                }
                else if (col >= matrix.Length)
                {
                    col = 0;
                }
                else if (row < 0)
                {
                    row = matrix.Length - 1;
                }
                else if (row >= matrix.Length)
                {
                    row = 0;
                }
            }
        }
    }
}
