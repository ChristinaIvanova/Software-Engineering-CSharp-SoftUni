using System;
using System.Linq;

namespace L03_Count_Uppercase_Words
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine()
                .Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
