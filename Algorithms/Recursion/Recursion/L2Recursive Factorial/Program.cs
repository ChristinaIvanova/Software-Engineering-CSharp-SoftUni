using System;

namespace L2Recursive_Factorial
{
    class Program
    {
        static long Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            var currentResult = num * Factorial(num - 1);
            return currentResult;
        }

        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var result = Factorial(num);

            Console.WriteLine(result);
        }
    }
}
