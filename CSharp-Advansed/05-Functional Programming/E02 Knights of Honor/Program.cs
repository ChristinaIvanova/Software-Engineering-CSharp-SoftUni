using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_Knights_of_Honor
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine()
                 .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            Func<string, string> format = x => $"Sir {x}";

            Action<List<string>> print = x => Console.WriteLine(string.Join
                (Environment.NewLine, x.Select(format)));

            print(names);
        }
    }
}
