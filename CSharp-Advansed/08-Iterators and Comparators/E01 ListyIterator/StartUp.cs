﻿using System;
using System.Linq;

namespace E01ListyIterator
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            ListyIterator<string> listyIterator = null;

            while (input != "END")
            {
                var commandArgs = input
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var command = commandArgs[0];

                switch (command)
                {
                    case "Create":
                        var valuesToAdd = commandArgs.Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(valuesToAdd);
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
