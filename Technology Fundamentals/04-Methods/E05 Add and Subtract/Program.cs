using System;

namespace E05_Add_and_Subtract
{
    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());

            int secondNumber = int.Parse(Console.ReadLine());

            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = GetSumOfTheFirstTwo(firstNumber,secondNumber);

            Console.WriteLine(GetSubtract(thirdNumber,sum));
        }

        private static int GetSubtract(int c,int sum)
        {
            return sum - c;
        }

        private static int GetSumOfTheFirstTwo(int a, int b)
        {
            return a + b;

        }
    }
}
