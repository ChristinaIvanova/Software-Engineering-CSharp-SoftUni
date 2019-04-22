﻿using System;
using System.Linq;
namespace _0006L_Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var evenSum = 0;
            var oddSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddSum+=numbers[i];
                }
            }
            Console.WriteLine(evenSum-oddSum);
        }
    }
}
