using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace L5_Generating_Combinations
{
    class Program
    {
        static void Gen(int[] vector, int[] combinations, int index, int border)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
            }
            else
            {
                for (int i = border; i < vector.Length; i++)
                {
                    combinations[index] = vector[i];
                    Gen(vector, combinations, index + 1, i + 1);
                }
            }

        }
        static void Main(string[] args)
        {
            var vector = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var combinationsLenght = int.Parse(Console.ReadLine());
            var combinations = new int[combinationsLenght];

            Gen(vector, combinations, 0, 0);
        }
    }
}
