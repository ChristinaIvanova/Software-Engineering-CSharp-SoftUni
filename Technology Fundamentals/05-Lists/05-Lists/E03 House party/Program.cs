using System;
using System.Linq;
using System.Collections.Generic;

namespace E03_House_party
{
    class Program
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guestsList = new List<string>();
            NewMethod(numberOfCommands, guestsList);
            Console.WriteLine(string.Join("\n", guestsList));
        }

        private static List<string> NewMethod(int numberOfCommands, List<string> guestsList)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] message = Console.ReadLine().Split();
                string name = message[0];
                if (guestsList.Contains(name))
                {
                    if (message.Length > 3)
                    {
                        guestsList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                else if (message.Length > 3)
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    guestsList.Add(name);
                }
            }
            return guestsList;
        }
    }
}
