using System;
using System.Linq;
namespace _0005L_Sum_Even_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
