using System;
using System.Linq;
namespace _0008L_Condense_Array_to_Number
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int[] condensed = new int[numbers.Length - 1];
            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = numbers[j] + numbers[j + 1];
                }

                numbers= condensed;
            }
            Console.WriteLine(condensed[0]);
        }
    }
}
