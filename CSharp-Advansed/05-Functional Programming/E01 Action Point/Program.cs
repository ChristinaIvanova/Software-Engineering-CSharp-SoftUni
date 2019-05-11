using System;
using System.Collections.Generic;
using System.Linq;

namespace E01_Action_Point
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> print = x => Console.WriteLine(string.Join
                (Environment.NewLine, x));

            print(names);
        }
    }
}
