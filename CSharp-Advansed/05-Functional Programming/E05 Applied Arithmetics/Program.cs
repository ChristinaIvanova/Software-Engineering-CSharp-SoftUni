using System;
using System.Linq;
using System.Collections.Generic;

namespace E05_Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> addFunc = x => x.Select(a => a += 1).ToList();
            Func<List<int>, List<int>> subtractFunc = x => x.Select(a => a -= 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = x => x.Select(a => a *= 2).ToList();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addFunc(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyFunc(numbers);
                        break;
                    case "subtract":
                        numbers = subtractFunc(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
