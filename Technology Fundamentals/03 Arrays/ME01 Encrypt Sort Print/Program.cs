using System;
using System.Text;
using System.Linq;
 
 
namespace FundamentalsIntro
{
    public class Program
    {
        public static void Main()
        {
            int numberOfArrays = int.Parse(Console.ReadLine());
            int[] arrayOfSum = new int[numberOfArrays];

            for (int i = 0; i < numberOfArrays; i++)
            {
                string name = Console.ReadLine();
                char[] charOfOneName = name.ToArray();

                int sum = 0;

                for (int j = 0; j < charOfOneName.Length; j++)
                {
                    if (charOfOneName[j] == 'A' || charOfOneName[j] == 'a' || charOfOneName[j] == 'E' ||
                      charOfOneName[j] == 'e' || charOfOneName[j] == 'I' || charOfOneName[j] == 'i' ||
                      charOfOneName[j] == 'O' || charOfOneName[j] == 'o' || charOfOneName[j] == 'U' ||
                      charOfOneName[j] == 'u')
                    {
                        sum += (charOfOneName[j] * charOfOneName.Length);
                    }
                    else
                    {
                        sum += (charOfOneName[j] / charOfOneName.Length);
                    }
                }

                arrayOfSum[i] = sum;
            }

            for (int i = 0; i < arrayOfSum.Length - 1; i++)
            {
                for (int j = 0; j < arrayOfSum.Length - 1; j++)
                {
                    if (arrayOfSum[j] > arrayOfSum[j + 1])
                    {
                        int temp = arrayOfSum[j];
                        arrayOfSum[j] = arrayOfSum[j + 1];
                        arrayOfSum[j + 1] = temp;
                    }
                }

            }

            foreach (int num in arrayOfSum)
            {
                Console.WriteLine(num);
            }

        }

    }
}
