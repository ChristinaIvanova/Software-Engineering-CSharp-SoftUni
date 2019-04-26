using System;

namespace L07_Pascal_Triangle
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            long[][] pascalArr = new long[rows][];
            pascalArr[0] = new long[1];
            pascalArr[0][0] = 1;

            for (int row = 1; row < rows; row++)
            {
                pascalArr[row] = new long[row + 1];
                pascalArr[row][0] = 1;
                pascalArr[row][pascalArr[row].Length - 1] = 1;

                for (int col = 1; col < pascalArr[row].Length - 1; col++)
                {
                    pascalArr[row][col] = pascalArr[row - 1][col]
                        + pascalArr[row - 1][col - 1];
                }
            }

            foreach (var row in pascalArr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
