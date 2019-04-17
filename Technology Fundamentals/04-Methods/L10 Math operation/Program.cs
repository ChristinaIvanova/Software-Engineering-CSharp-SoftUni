using System;

namespace L10_Math_operation
{
    class Program
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());
            double result = GetCalculate(firstNumber, operators, secondNumber);
            Console.WriteLine(result);
        }

        private static double GetCalculate(int a, string @operator, int b)
        {
            double result = 0;
            switch (@operator)
            {
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
