using System;
using System.Linq;
namespace _008Е_Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int magicNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length; i++)
            {
                int sum = 0;
                sum = numbers[i];
                for (int j = i; j < numbers.Length - 1; j++)
                {
                    sum += numbers[j + 1];
                    if (sum != magicNumber)
                    {
                        sum -= numbers[j + 1];
                    }
                    else
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j+1]}");
                        //sum -= numbers[j + 1];
                    }
                }
            }
        }
    }
}

