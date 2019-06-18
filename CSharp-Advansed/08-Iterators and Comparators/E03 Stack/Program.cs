namespace E03Stack
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            CustomStack<int> customStack = new CustomStack<int>();

            while (input != "END")
            {
                var commandArgs = input.Split(" ", 2);
                var command = commandArgs[0];

                if (command == "Push")
                {
                    var valuesToAdd = commandArgs[1]
                               .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

                    customStack.Push(valuesToAdd);
                }
                else
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var number in customStack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
