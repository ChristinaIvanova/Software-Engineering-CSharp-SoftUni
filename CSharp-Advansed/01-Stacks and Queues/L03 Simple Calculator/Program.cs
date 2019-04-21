using System;
using System.Linq;
using System.Collections.Generic;
namespace L03_Simple_Calculator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            var symbols = new Stack<string>(input.Reverse());

            var result = int.Parse(symbols.Pop());

            while (symbols.Any())
            {
                var nextSymbol = symbols.Pop();

                switch (nextSymbol)
                {
                    case "+":
                        result += int.Parse(symbols.Pop());
                        break;
                    case "-":
                        result -= int.Parse(symbols.Pop());
                        break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
