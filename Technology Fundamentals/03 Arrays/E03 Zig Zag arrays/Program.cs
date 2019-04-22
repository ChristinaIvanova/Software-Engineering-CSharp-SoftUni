using System;
using System.Linq;

namespace _003Е_Zig_Zag_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] firstZigZag = new int[lines];
            int[] secondZigZag = new int[lines];
            string first = null;
            string second = null;
            for (int i = 0; i < lines; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (i % 2 == 0)
                {
                    firstZigZag[i] = arr[0];
                    secondZigZag[i] = arr[1];
                }
                else
                {
                    firstZigZag[i] = arr[1];
                    secondZigZag[i] = arr[0];
                }
                first = string.Join(' ', firstZigZag);
                second = string.Join(' ', secondZigZag);
            }
            Console.WriteLine($"{first} {Environment.NewLine}{second}");
        }
    }
}
