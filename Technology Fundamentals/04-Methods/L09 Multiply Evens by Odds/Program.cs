using System;

namespace L09_Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main()
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumEvens = GetSumOfEvenDigits(number);

            int sumOdds = GetSumOfOddDigits(number);

            GetMultiple(sumEvens, sumOdds);          
        }

        private static void GetMultiple(int sumEvens, int sumOdds)
        {
            int result = sumEvens * sumOdds;
            Console.WriteLine(result);
        }

        private static int GetSumOfOddDigits(int number)
        {
            string numberToString = number.ToString();
            int sumOdd = 0;

            foreach (char symbol in numberToString)
            {
                int digit = symbol - '0';
                if (digit % 2 != 0)
                {
                    sumOdd += digit;
                }
            }
            return sumOdd; ;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            string numberToString = number.ToString();
            int sumEven = 0;

            foreach (char symbol in numberToString)
            {
                int digit = symbol - '0';
                if (digit % 2 == 0)
                {
                    sumEven += digit;
                }
            }
            return sumEven;
        }
    }
}
