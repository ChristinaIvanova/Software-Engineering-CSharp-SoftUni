using System;
using System.Collections.Generic;
using System.Text;

namespace E09_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandCount = int.Parse(Console.ReadLine());

            Stack<string> previousCommands = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < commandCount; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string command = commands[0];

                switch (command)
                {
                    case "1":
                        previousCommands.Push(text);
                        text += commands[1];
                        break;
                    case "2":
                        previousCommands.Push(text);
                        int removeElements = int.Parse(commands[1]);
                        text = text.Substring(0, text.Length - removeElements);
                        break;
                    case "3":
                        int index = int.Parse(commands[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text = previousCommands.Pop();
                        break;
                }
            }
        }
    }
}
