using System;
using System.Linq;
namespace _009Е_Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int[] sequence = new int[lenght];
            int longestSub = -1;
            int longestSubIndex = -1;
            int longestSubSum = -1;
            int indexOfSequence = 1;
            string input = string.Empty;
            while (input!="Clone them!")
            {
               int[] currentSequence = input.
                    Split('!',StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse)
                    .ToArray();
                int sub = 0;
                int subIndex = -1;
                int subSum =0;
                int count = 0;
                for (int i = 0; i < lenght; i++)
                {
                    if (currentSequence[i]==1)
                    {
                        count++;
                        subSum++;
                    }
                    else
                    {
                        if (count>sub)
                        {
                            sub = count;
                            subIndex = i - count;
                        }
                        count = 0;
                    }
                }
                if (sub>longestSub)
                {
                    longestSubIndex = subIndex;
                    longestSub = sub;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                }
               else if (sub == longestSub&& longestSubIndex>subIndex)
                {
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    sequence = currentSequence;
                }
                else if (sub == longestSub && longestSubIndex == subIndex
                    &&longestSubSum<subSum)
                {
                    longestSubSum = subSum;
                    sequence = currentSequence;
                }
                indexOfSequence++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {indexOfSequence} with sum: {longestSubSum}.");
        }
    }
}
