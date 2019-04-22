//using System;
//using System.Linq;
//namespace _04ME_Fold_and_sum
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] row = Console.ReadLine()
//                 .Split()
//                 .Select(int.Parse)
//                 .ToArray();
//            int integer = row.Length / 4;
//            int[,] matrixArray = new int[2, 2 * integer];
//            int[] firstRow = new int[2 * integer];
//            int[] SecondRow = new int[2 * integer];
//            int temp = integer;
//            for (int i = integer - 1; i >= 0; i--)
//            {
//                matrixArray[0, 1 - i] = row[i];
//            }
//            for (int i = row.Length - 1; i > row.Length - integer - 1; i--)
//            {
//                matrixArray[0, temp] = row[i];
//                temp++;
//            }

//        }
//    }
//}
using System;
using System.Linq;

namespace FoldAndSum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int middleStartIndex = (sequence.Length / 2) / 2;
            int middleEndIndex = middleStartIndex + sequence.Length / 2;

            int summingIndex = middleStartIndex - 1;

            for (int i = middleStartIndex; i < middleEndIndex; i++)
            {
                int sum = sequence[i] + sequence[summingIndex];
                Console.Write($"{sum} ");
                summingIndex--;
                if (summingIndex < 0)
                {
                    summingIndex = sequence.Length - 1;
                }
            }
        }
    }
}

