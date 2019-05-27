using System;
using System.Linq;
using System.Collections.Generic;

namespace E07_The_V_Logger
{
    class Vlogger
    {
        public string Name { get; set; }

        public HashSet<string> Followers { get; set; }

        public HashSet<string> Following { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var vloggers = new List<Vlogger>();

            var input = Console.ReadLine();

            while (input != "Statistics")
            {
                var vloggersPart = input.Split();

                var name = vloggersPart[0];

                var existingUser = vloggers.FirstOrDefault(x => x.Name == name);

                switch (vloggersPart[1])
                {
                    case "joined":
                        if (existingUser == null)
                        {
                            Vlogger vlogger = new Vlogger();
                            vlogger.Name = name;

                            vloggers.Add(vlogger);

                            var indexOfVlogger = vloggers.FindIndex(x => x.Name == name);
                            vloggers[indexOfVlogger].Followers = new HashSet<string>();
                            vloggers[indexOfVlogger].Following = new HashSet<string>();
                        }
                        break;
                    case "followed":
                        var userToFollow = vloggersPart[2];

                        var existingVlogger = vloggers.FirstOrDefault(x => x.Name == userToFollow);

                        if (name != userToFollow)
                        {
                            if (existingUser != null && existingVlogger != null)
                            {
                                var indexOfExistingUser = vloggers.FindIndex(x => x.Name == name);
                                vloggers[indexOfExistingUser].Following.Add(userToFollow);

                                var indexOfUserToFollow = vloggers.FindIndex(x => x.Name == userToFollow);
                                vloggers[indexOfUserToFollow].Followers.Add(name);
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            PrintTheVLoggers(vloggers);
        }

        private static void PrintTheVLoggers(List<Vlogger> vloggers)
        {
            var totalVloggrers = vloggers.Count();
            Console.WriteLine($"The V-Logger has a total of {totalVloggrers} vloggers in its logs.");

            var count = 1;

            foreach (var vlogger in vloggers
                .OrderByDescending(x => x.Followers.Count)
                .ThenBy(x => x.Following.Count))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                    foreach (var follower in vlogger.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                }

                count++;
            }
        }
    }
}
