using System;

namespace _0002L_Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = new int[number];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }
    }
}
