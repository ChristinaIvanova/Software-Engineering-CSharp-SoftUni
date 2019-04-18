using System;

namespace E08_Factorial_Division
{
    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long firstFactorial = GetFactoriel(firstNumber);
            long secondFactorial = GetFactoriel(secondNumber);

            double divided = (double)firstFactorial / secondFactorial;
            Console.WriteLine($"{divided:f2}");
        }
        private static long GetFactoriel(int a)
        {
            long fact = 1;

            while (a > 1)
            {
                fact = a * fact;
                a -= 1;
            }
            return fact;
        }
    }
}
