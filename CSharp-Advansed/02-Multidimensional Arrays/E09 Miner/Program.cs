using System;
using System.Linq;

namespace E09_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var field = new char[rows][];

            var commands = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var startingCoals = 0;

            for (int i = 0; i < field.Length; i++)
            {
                var rowArgs = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                field[i] = rowArgs;

                startingCoals += rowArgs.Where(x => x == 'c').Count();
            }

            var countCoals = 0;

            var coords = GetStartPosition(field).Split();
            var startRow = int.Parse(coords[0]);
            var startCol = int.Parse(coords[1]);

            var currentRow = startRow;
            var currentCol = startCol;

            bool isGameOver = false;
            bool isAllCollected = false;

            foreach (var command in commands)
            {
                var row = currentRow;
                var col = currentCol;

                switch (command)
                {
                    case "left":
                        currentCol -= 1;
                        break;
                    case "right":
                        currentCol += 1;
                        break;
                    case "up":
                        currentRow -= 1;
                        break;
                    case "down":
                        currentRow += 1;
                        break;
                }

                if (isCellInMatrix(currentRow, currentCol, field))
                {
                    if (field[currentRow][currentCol] == 'c')
                    {
                        field[currentRow][currentCol] = '*';
                        countCoals++;

                        if (startingCoals == countCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                            isAllCollected = true;
                            return;
                        }
                    }
                    else if (field[currentRow][currentCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                        isGameOver = true;
                        return;
                    }
                }
                else
                {
                    currentRow = row;
                    currentCol = col;
                }
            }

            if (!isAllCollected & !isGameOver)
            {
                Console.WriteLine($"{startingCoals - countCoals} coals left. ({currentRow}, {currentCol})");
            }
        }

        private static bool isCellInMatrix(int row, int col, char[][] field)
        {
            if (row >= 0 && row < field.Length
                && col >= 0 && col < field.Length)
            {
                return true;
            }

            return false;
        }

        private static string GetStartPosition(char[][] field)
        {
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < field.Length; i++)
            {
                var row = field[i];
                int index = Array.FindIndex(row, x => x == 's');

                if (index != -1)
                {
                    startRow = i;
                    startCol = index;
                }
            }

            return $"{startRow} {startCol}";
        }

    }
}
