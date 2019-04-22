using System;
using System.Linq;
namespace _0007L_Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sum = 0;
            var countEqual = 0;
            for (int i = 0; i < arr1.Length; i++)
            {

                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
                else
                {
                    sum += arr1[i];
                    countEqual++;
                }
            }
            if (sum > 0 && countEqual==arr1.Length)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }

        }
    }
}
