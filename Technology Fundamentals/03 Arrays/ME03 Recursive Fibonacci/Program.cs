using System;

namespace _03ME_Recursive_Fibonacci
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            
            int[] fib = new int[number + 1];
            fib[0]=0;
            fib[1]=1;
            for (int i = 2; i < number+1; i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
            }
            Console.WriteLine(fib[number]);
        }
    }
}
