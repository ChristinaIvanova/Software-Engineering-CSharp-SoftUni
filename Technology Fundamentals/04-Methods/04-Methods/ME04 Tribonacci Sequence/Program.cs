using System;

namespace ME04_Tribonacci_Sequence
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] tribSequence = TribonacciSequence(number);
            PrintTribonacciSequence(tribSequence);
        }

        private static void PrintTribonacciSequence(int[] tribSequence)
        {
            for (int i = 1; i < tribSequence.Length; i++)
            {
                Console.Write(tribSequence[i] + " ");
            }
        }

        private static int[] TribonacciSequence(int number)
        {
            int[] tribSequence = new int[number + 1];
            tribSequence[0] = 0;
            tribSequence[1] = 1;
            tribSequence[2] = 1;
            for (int i = 3; i < tribSequence.Length; i++)
            {
                tribSequence[i] = tribSequence[i - 1] + tribSequence[i - 2]
                    + tribSequence[i - 3];
            }
            return tribSequence;
        }
    }
}
