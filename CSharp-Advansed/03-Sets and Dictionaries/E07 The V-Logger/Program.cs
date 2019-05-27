using System;
using System.Linq;
using System.Collections.Generic;

namespace E07_The_V_Logger
{
    class Vlogger
    {
        public string Name { get; set; }

        public HashSet<string> Followers { get; set; } = new HashSet<string>();

        public HashSet<string> Followings { get; set; } = new HashSet<string>();
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

                        }
                        break;
                    case "followed":
                        var userToFollow = vloggersPart[2];

                        var existingVloggerToFollow = vloggers.FirstOrDefault(x => x.Name == userToFollow);

                        if (existingUser != null && existingVloggerToFollow != null
                           && name != userToFollow)
                        {
                            existingUser.Followings.Add(userToFollow);

                            existingVloggerToFollow.Followers.Add(name);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            PrintTheVLoggers(vloggers);
        }

        private static void PrintTheVLoggers(List<Vlogger> vloggers)
        {
            vloggers = vloggers
               .OrderByDescending(x => x.Followers.Count)
               .ThenBy(x => x.Followings.Count)
               .ToList();

            var totalVloggrers = vloggers.Count();
            Console.WriteLine($"The V-Logger has a total of {totalVloggrers} vloggers in its logs.");

            var count = 1;

            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Followings.Count} following");

                if (count == 1)
                {
                    foreach (var follower in vlogger.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
