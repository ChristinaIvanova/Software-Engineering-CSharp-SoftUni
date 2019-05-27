using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var symbols = new SortedDictionary<char, int>();

            var text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = 0;
                }

                symbols[symbol]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
