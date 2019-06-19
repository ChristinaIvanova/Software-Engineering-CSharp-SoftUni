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
                var warrorsInput = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse);

                if (i % 3 == 0)
                {
                    var additionalWall = int.Parse(Console.ReadLine());
                    plates.Add(additionalWall);
                }

                warrorsInput.ToList().ForEach(x => warriors.Push(x));

                while (plates.Any() && warriors.Any())
                {
                    var currentWarrior = warriors.Pop();
                    var currentPlate = plates[0];

                    if (currentWarrior > currentPlate)
                    {
                        warriors.Push(currentWarrior - currentPlate);
                        plates.RemoveAt(0);
                    }
                    else if (currentWarrior == currentPlate)
                    {
                        plates.RemoveAt(0);
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        plates[0] = currentPlate - currentWarrior;
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (warriors.Any())
            {
                var leftwarriors = string.Join(", ", warriors);

                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {leftwarriors}");
            }
            else
            {
                var leftPlates = string.Join(", ", plates);

                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {leftPlates}");
            }
        }
    }
}
