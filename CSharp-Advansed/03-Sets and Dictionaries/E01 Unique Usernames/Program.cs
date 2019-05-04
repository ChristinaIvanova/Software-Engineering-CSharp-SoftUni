using System;
using System.Collections.Generic;

namespace E01_Unique_Usernames
{
    class Program
    {
        static void Main()
        {
            var usernames = new HashSet<string>();

            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
