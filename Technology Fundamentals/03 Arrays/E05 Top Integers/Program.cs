using System;
using System.Linq;
namespace _005E_Top_Integers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int biggerNumber = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    biggerNumber = numbers[i];
                    Console.Write($"{biggerNumber} ");
                }
            }
            Console.WriteLine(numbers[numbers.Length - 1]);
        }
    }
}
