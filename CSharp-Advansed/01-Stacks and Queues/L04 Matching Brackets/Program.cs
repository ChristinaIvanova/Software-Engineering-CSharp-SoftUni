using System;
using System.Collections.Generic;
using System.Linq;

namespace L04_Matching_brackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> symbols = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var a = input[i];
                if (input[i] == '(')
                {
                    symbols.Push(i);
                }
                else if (input[i] == ')')
                {
                    var openBracketIndex = symbols.Pop();

                    Console.WriteLine(input.Substring(openBracketIndex,i-openBracketIndex+1));
                }
            }
        }
    }
}
