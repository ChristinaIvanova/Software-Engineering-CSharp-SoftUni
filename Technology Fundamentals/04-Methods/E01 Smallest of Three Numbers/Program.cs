using System;

namespace E01_Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int[] numbers = new int[] { firstNumber, secondNumber, thirdNumber };

            int smallest = int.MaxValue;
            smallest = GetTheSmallestNumber(numbers, smallest);

            Console.WriteLine(smallest);
        }

        private static int GetTheSmallestNumber(int[] numbers, int smallest)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]<smallest)
                {
                    smallest = numbers[i];
                }                       
            }        
           return smallest;
        }
    }
}
