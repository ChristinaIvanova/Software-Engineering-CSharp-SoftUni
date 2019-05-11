using System;
using System.Linq;

namespace E05_Applied_Arithmetics_sol2
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            Action<string> arithmetics = operation =>
              {
                  switch (operation)
                  {
                      case "add":
                          numbers = numbers.Select(n => n + 1).ToList();
                          break;
                      case "multiply":
                          numbers = numbers.Select(n => n * 2).ToList();
                          break;
                      case "subtract":
                          numbers = numbers.Select(n => n - 1).ToList();
                          break;
                      case "print":
                          Console.WriteLine(string.Join(" ", numbers));
                          break;
                  }
              };

            while (command!="end")
            {
                arithmetics(command);

                command = Console.ReadLine();
            }
        }
    }
}
