using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Trojan_2
{
    class Program
    {
        static void Main()
        {
            var waves = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            var warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                var rocksInput = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

                if (i % 3 == 0)
                {
                    var additionalWall = int.Parse(Console.ReadLine());
                    plates.Add(additionalWall);
                }

                rocksInput.ForEach(x => warriors.Push(x));

                while (plates.Any() && warriors.Any())
                {
                    var currentRock = warriors.Pop();
                    var currentWall = plates[0];

                    if (currentRock > currentWall)
                    {
                        warriors.Push(currentRock - currentWall);
                        plates.RemoveAt(0);
                    }
                    else if (currentRock == currentWall)
                    {
                        plates.RemoveAt(0);
                    }
                    else if (currentRock < currentWall)
                    {
                        plates[0]=currentWall - currentRock;
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (warriors.Any())
            {
                var leftRocks = string.Join(", ", warriors);

                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {leftRocks}");
            }
            else
            {
                var leftWalls = string.Join(", ", plates);
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {leftWalls}");
            }
        }
    }
}
