using System;
using System.Linq;
namespace _006E_Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '},
            StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sumRight = 0;
            int sumLeft = 0;
            int countNo = 0;
            int countYes = 0;
            
            for (int i = 1; i < numbers.Length; i++)
            {
                    sumLeft += numbers[i - 1];
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    sumRight += numbers[j + i + 1];

                }
                if (numbers.Length <= 2)
                {
                    sumLeft = 0;
                    sumRight = numbers[1];
                }
                if (sumRight == sumLeft)
                {
                    countYes = i;
                }
                else
                {
                    countNo++;
                }
                sumRight = 0;

               
                //sumRight= numbers.Skip(i+1).Sum();
                // sumLeft=numbers.Skip(i - 1).Sum();

                //if (sumRight==sumLeft)
                //{
                //    Console.WriteLine(i);
                //}
                //else
                //{
                //    Console.WriteLine("no");
                //}
            }
            if (countNo > 0 && countYes == 0)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(countYes);
            }
        }
    }
}
