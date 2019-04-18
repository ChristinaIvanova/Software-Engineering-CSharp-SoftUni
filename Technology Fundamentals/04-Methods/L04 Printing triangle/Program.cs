using System;

namespace L04_Printing_triangle
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
            PrintReversedTriangle(number);
        }

        private static void PrintReversedTriangle(int maxNumber)
        {
            for (int row = maxNumber - 1; row >= 0; row--)
            {
                PrintRow(row);

                Console.WriteLine();
            }
        }

        private static void PrintTriangle(int maxNumber)
        {
            
            for (int row = 1; row <= maxNumber; row++)
            {
                PrintRow(row);

                Console.WriteLine();
            }
        }

        private static void PrintRow(int row)
        {
            for (int number = 1; number <= row; number++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
