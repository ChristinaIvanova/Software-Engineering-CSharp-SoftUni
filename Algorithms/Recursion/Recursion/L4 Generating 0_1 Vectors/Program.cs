using System;
using System.Runtime.InteropServices;

namespace L4_Generating_0_1_Vectors
{
    class Program
    {
        static void Gen(int index, int[] vector)
        {
            if (index == vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen(index+1, vector);
                }
            }
        }

        static void Print(int[] vector)
        {
            Console.WriteLine(string.Join("", vector));
        }
        static void Main(string[] args)
        {

            var num = int.Parse(Console.ReadLine());

            var vector = new int[num];

            Gen(0, vector);
        }
    }
}
