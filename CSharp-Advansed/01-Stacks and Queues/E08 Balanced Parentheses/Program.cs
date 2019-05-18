using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];

                if (symbol == ')' || symbol == '}' || symbol == ']')
                {
                    if (stack.Any())
                    {
                        if (stack.Peek() == '(' && symbol == ')' || stack.Peek() == '[' && symbol == ']' 
                            || stack.Peek() == '{' && symbol == '}')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                        }
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
                else
                {
                    stack.Push(symbol);
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
