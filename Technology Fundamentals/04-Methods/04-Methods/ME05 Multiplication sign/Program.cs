using System;

namespace ME05_Multiplication_sign
{
    class Program
    {
        static void Main()
        {
            int countNegative = 0;

            int zero = 0;

            string resultSign = string.Empty;

            int firstNumber = int.Parse(Console.ReadLine());

            countNegative += NegativeSign(firstNumber);

            zero += ZeroSign(firstNumber);

            int secondNumber = int.Parse(Console.ReadLine());

            countNegative +=NegativeSign(secondNumber);

            zero += ZeroSign(secondNumber);

            int thirdNumber = int.Parse(Console.ReadLine());

            countNegative += NegativeSign(thirdNumber);

            zero += ZeroSign(thirdNumber);

            if (countNegative % 2 != 0)
            {
                resultSign = "negative";
            }
            else if (countNegative % 2 == 0 || countNegative == 0)
            {
                resultSign = "positive";
            }

            if (zero > 0)
            {
                resultSign = "zero";
            }

            Console.WriteLine(resultSign);
        }

        private static int ZeroSign(int number)
        {
            int zero = 0;

            if (number==0)
            {
                zero++;
            }
            return zero;
        }

        private static int NegativeSign(int number)
        {
            int countNegative = 0;

            if (number < 0)
            {
                countNegative++;
            }

            return countNegative;
        }
    }
}
