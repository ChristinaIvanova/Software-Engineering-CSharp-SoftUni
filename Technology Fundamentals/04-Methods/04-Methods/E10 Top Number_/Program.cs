using System;

namespace E10_Top_Number_
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            DivisibleSumAndOddDigit(number);
        }

        private static void DivisibleSumAndOddDigit(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                string numberToString = i.ToString();

                int sumOfDigits = 0;

                int countOddDigits = 0;

                for (int j = 0; j < numberToString.Length; j++)
                {
                    int digit = numberToString[j] - '0';

                    sumOfDigits += digit;

                    if (digit % 2 != 0)
                    {
                        countOddDigits++;
                    }
                }

                if (sumOfDigits % 8 == 0 && countOddDigits > 0)
                {
                    Console.WriteLine(numberToString);
                }
            }
        }
    }
}
