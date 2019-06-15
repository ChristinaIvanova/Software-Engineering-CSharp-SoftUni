using System;
using System.Linq;

namespace Excel_Functions
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var table = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                table[i] = currentRow;
            }

            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var command = commandArgs[0];
            var header = commandArgs[1];
            var headerIndex = Array.FindIndex(table[0], x => x == header);

            switch (command)
            {
                case "hide":
                    table = DeleteColumn(table, headerIndex);
                    break;
                case "sort":
                    GetSortedTable(table, headerIndex);
                    break;
                case "filter":
                    var value = commandArgs[2];
                    var filterColumn = GetColomn(table, headerIndex);

                    table = GetFilteredTable(table, value, filterColumn);
                    break;
            }

            foreach (var row in table)
            {
                Console.WriteLine(string.Join(" | ", row));
            }
        }

        private static string[][] DeleteColumn(string[][] matrix, int columnNumber)
        {
            return matrix
                 .Select(arr => arr.Where((item, i) => i != columnNumber)
               .ToArray())
               .ToArray();
        }

        private static void GetSortedTable(string[][] table, int headerIndex)
        {
            var sortedTable = table.Skip(1).OrderBy(row => row[headerIndex]).ToArray();
            for (int i = 1; i < table.Length; i++)
            {
                table[i] = sortedTable[i - 1];
            }
        }

        private static string[] GetColomn(string[][] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x][columnNumber])
                .ToArray();
        }
        
        private static string[][] GetFilteredTable(string[][] table, string value, string[] filterColumn)
        {
            var filteredRowsCount = filterColumn.Count(x => x == value);

            var filteredTable = new string[filteredRowsCount + 1][];
            filteredTable[0] = table[0];

            var rowToAdd = 1;

            for (int i = 0; i < table.Length; i++)
            {
                if (filterColumn[i] == value)
                {
                    filteredTable[rowToAdd] = table[i];
                    rowToAdd++;
                }
            }

            return filteredTable;
        }
    }
}
