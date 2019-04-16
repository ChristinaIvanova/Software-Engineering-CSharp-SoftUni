using System;

namespace L01_Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);

            PrintReverseTriangle(number);
        }

        private static void PrintReverseTriangle(int number)
        {
            for (int row = number-1; row >= 1; row--)
            {
                PrintRow(row);
            }
        }

        private static void PrintTriangle(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                PrintRow(row);
            }
        }

        private static void PrintRow(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
