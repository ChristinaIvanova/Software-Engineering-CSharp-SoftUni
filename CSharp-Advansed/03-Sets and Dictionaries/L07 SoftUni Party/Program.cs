using System;
using System.Collections.Generic;

namespace L07_SoftUni_Party
{
    class Program
    {
        static void Main()
        {
            var regularGuests = new HashSet<string>();
            var vipGuests = new HashSet<string>();

            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input!="END")
            {
                vipGuests.Remove(input);
                regularGuests.Remove(input);

                input = Console.ReadLine();
            }

            var guestNotGoing = vipGuests.Count + regularGuests.Count;

            Console.WriteLine(guestNotGoing);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
