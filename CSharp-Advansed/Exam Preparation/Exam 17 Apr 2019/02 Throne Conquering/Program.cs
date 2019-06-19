using System;
using System.Linq;

namespace _02_Throne_Conquering
{
    class Program
    {
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());

            var rows = int.Parse(Console.ReadLine());

            var field = new char[rows][];

            var throneLocationRow = 0;
            var throneLocationCol = 0;

            var parisLocationRow = 0;
            var parisLocationCol = 0;

            for (int i = 0; i < rows; i++)
            {
                var currentRowField = Console.ReadLine().ToCharArray();
                field[i] = currentRowField;

                if (currentRowField.Contains('H'))
                {
                    throneLocationRow = i;
                    throneLocationCol = Array.FindIndex(currentRowField, item => item == 'H');
                }

                if (currentRowField.Contains('P'))
                {
                    parisLocationRow = i;
                    parisLocationCol = Array.FindIndex(currentRowField, item => item == 'P');
                }
            }

            bool isOver = false;

            while (!isOver)
            {
                var commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = commandArgs[0];
                var enemyRow = int.Parse(commandArgs[1]);
                var enemyCol = int.Parse(commandArgs[2]);

                field[enemyRow][enemyCol] = 'S';

                var currentRow = parisLocationRow;
                var currentCol = parisLocationCol;

                switch (command)
                {
                    case "up":
                        currentRow -= 1;
                        break;
                    case "down":
                        currentRow += 1;
                        break;
                    case "left":
                        currentCol -= 1;
                        break;
                    case "right":
                        currentCol += 1;
                        break;
                }

                ParisMovement(ref energy, field, ref parisLocationRow, ref parisLocationCol, ref currentRow, ref currentCol);

                if (energy <= 0)
                {
                    field[parisLocationRow][parisLocationCol] = 'X';
                    isOver = true;
                }

                if (parisLocationRow == throneLocationRow
                    && parisLocationCol == throneLocationCol)
                {
                    field[throneLocationRow][throneLocationCol] = '-';
                    isOver = true;
                }
            }

            if (field[throneLocationRow][throneLocationCol] == '-')
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisLocationRow};{parisLocationCol}.");
            }

            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void ParisMovement(ref int energy, char[][] field, ref int parisLocationRow, ref int parisLocationCol, ref int currentRow, ref int currentCol)
        {
            if (currentRow >= 0 && currentRow < field.Length
            && currentCol >= 0 && currentCol < field.Length)
            {
                field[parisLocationRow][parisLocationCol] = '-';

                parisLocationRow = currentRow;
                parisLocationCol = currentCol;
            }

            energy -= 1;

            if (field[parisLocationRow][parisLocationCol] == 'S')
            {
                energy -= 2;
            }

            field[parisLocationRow][parisLocationCol] = 'P';
        }
    }
}


