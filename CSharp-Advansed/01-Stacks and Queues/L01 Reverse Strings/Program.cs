using System;
using System.Collections.Generic;

namespace L01_Reverse_Strings
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<char>();
            var input = Console.ReadLine();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
