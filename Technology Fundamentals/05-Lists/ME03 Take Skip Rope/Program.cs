using System;
using System.Linq;
using System.Collections.Generic;

namespace ME03_Take_Skip_Rope
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            var numbers = text.Where(symbol => char.IsDigit(symbol))
                .Select(symbol => int.Parse(symbol.ToString()))
                .ToList();
            var nonNumbers = text.Where(symbol => !char.IsDigit(symbol)).ToList();
            var takeList = numbers.Where((number,index) => index % 2 == 0).ToList();
            var skipList = numbers.Where((number,index) => index % 2 != 0).ToList();
            string result = string.Empty;
            var totalSkip = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                var skip = skipList[i];
                var take = takeList[i];
                var current = new string(nonNumbers.Skip(totalSkip).Take(take).ToArray());
                result = string.Concat(result, current);
                totalSkip += skip + take;
            }
            Console.WriteLine(result);
        }
    }
}
