using System;
using System.Linq;
namespace _007E_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int maxCount = 0;
            int count = 0;
            int longestSeqIndex = 0;  
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i]==array[i+1])
                {
                    count++;
                    if (count>maxCount)
                    {
                        longestSeqIndex = i - count+1;
                        maxCount = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            for (int i = longestSeqIndex; i <= longestSeqIndex+maxCount; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
