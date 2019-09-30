using System;

namespace L1Recursive_Array_Sum
{
    class Program
    {
        static int Sum(int[] arr, int startIndex)
        {
            if (startIndex == arr.Length)
            {
                return 0;
            }

            var currentSum= arr[startIndex] + Sum(arr, startIndex + 1);
            return currentSum;
        }


        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            var result = Sum(numbers, 0);
            Console.WriteLine(result);
        }
    }
}
