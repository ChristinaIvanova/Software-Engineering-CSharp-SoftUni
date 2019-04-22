using System;
using System.Linq;
namespace _0003L_Rounding_Numbers
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                double originalNumber = numbers[i];
                int roundedNumber = (int)Math.Round(originalNumber, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{originalNumber} => {roundedNumber}");
            }
        }
    }
}
