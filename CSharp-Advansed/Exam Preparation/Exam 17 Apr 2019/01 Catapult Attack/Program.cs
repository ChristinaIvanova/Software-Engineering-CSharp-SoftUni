using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Catapult_Attack
{
    class Program
    {
        static void Main()
        {
            var piles = int.Parse(Console.ReadLine());

            var wallsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var walls = new Stack<int>(wallsInput.Reverse());
            var rocks = new Stack<int>();

            for (int i = 1; i <= piles; i++)
            {
                var rocksInput = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

                if (i % 3 == 0)
                {
                    var additionalWall = int.Parse(Console.ReadLine());
                    walls.Push(additionalWall);
                }

                rocksInput.ForEach(x => rocks.Push(x));
                
                while (walls.Any() && rocks.Any())
                {
                    var currentRock = rocks.Peek();
                    var currentWall = walls.Peek();

                    if (currentRock > currentWall)
                    {
                        rocks.Pop();
                        rocks.Push(currentRock - currentWall);
                        walls.Pop();
                    }
                    else if (currentRock == currentWall)
                    {
                        rocks.Pop();
                        walls.Pop();
                    }
                    else if (currentRock < currentWall)
                    {
                        rocks.Pop();
                        walls.Pop();
                        walls.Push(currentWall - currentRock);
                    }

                }

                if (walls.Count == 0)
                {
                    break;
                }
            }

            if (rocks.Any())
            {
                var leftRocks = string.Join(", ", rocks);
                Console.WriteLine($"Rocks left: {leftRocks}");
            }
            else
            {
                var finalWalls = new Stack<int>(walls);
                var leftWalls = string.Join(" ", finalWalls);
                Console.WriteLine($"Walls left: {leftWalls}");
            }
        }
    }
}
