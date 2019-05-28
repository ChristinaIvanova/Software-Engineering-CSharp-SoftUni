using System;
using System.Linq;
using System.Collections.Generic;

namespace E08_Ranking
{
    class Program
    {
        static void Main()
        {
            var contests = new Dictionary<string, string>();
            var candidatesScores = new SortedDictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (input != "end of contests")
            {
                var contestPart = input
                    .Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var contest = contestPart[0];
                var password = contestPart[1];

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = password;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                var candidatePart = input
                    .Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var contest = candidatePart[0];
                var password = candidatePart[1];
                var candidate = candidatePart[2];
                var points = int.Parse(candidatePart[3]);

                if (contests.ContainsKey(contest)
                    && contests[contest] == password)
                {
                    if (!candidatesScores.ContainsKey(candidate))
                    {
                        candidatesScores[candidate] = new Dictionary<string, int>();
                    }

                    if (!candidatesScores[candidate].ContainsKey(contest))
                    {
                        candidatesScores[candidate][contest] = 0;
                    }

                    if (candidatesScores[candidate][contest] < points)
                    {
                        candidatesScores[candidate][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            PrintBestCandidate(candidatesScores);
            PrintRanking(candidatesScores);
        }

        private static void PrintRanking(SortedDictionary<string, Dictionary<string, int>> candidatesScores)
        {
            Console.WriteLine("Ranking:");
            foreach (var kvp in candidatesScores)
            {
                Console.WriteLine($"{kvp.Key}");

                Console.WriteLine(string.Join
                    (Environment.NewLine, kvp.Value.OrderByDescending(x => x.Value)
                   .Select(a => $"#  {a.Key} -> {a.Value}")));
            }
        }

        private static void PrintBestCandidate(SortedDictionary<string, Dictionary<string, int>> candidatesScores)
        {
            var totalPoints = new Dictionary<string, int>();
            foreach (var kvp in candidatesScores)
            {
                totalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            var bestCandidate = totalPoints.OrderByDescending(x => x.Value).FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value} points.");
        }
    }
}
