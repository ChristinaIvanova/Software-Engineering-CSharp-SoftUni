using System;

namespace L07_Math_Power
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(GetPower(number, power)); 
        }

        private static double GetPower(double number, int power)
        {
            double result = 0d;

            result = Math.Pow(number, power);

            return result;
        }
    }
}
