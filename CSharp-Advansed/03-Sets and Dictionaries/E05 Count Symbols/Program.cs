using System;
using System.Collections.Generic;
using System.Linq;

namespace E05_Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var symbols = new Dictionary<char, int>();

            var text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (!symbols.ContainsKey(symbol))
                {
                    symbols[symbol] = 0;
                }

                symbols[symbol]++;
            }

            foreach (var kvp in symbols.OrderBy(x => x.Key))
            {
                var symbol = kvp.Key;
                var repeatedTimes = kvp.Value;

                Console.WriteLine($"{symbol}: {repeatedTimes} time/s");
            }
        }
    }
}
