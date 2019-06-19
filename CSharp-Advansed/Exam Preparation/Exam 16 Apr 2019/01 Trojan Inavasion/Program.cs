using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Catapult_Attack
{
    class Program
    {
        static void Main()
        {
            var waves = int.Parse(Console.ReadLine());

            var platesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var plates = new Stack<int>(platesInput.Reverse());
            var warriors = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                var warriorsInput = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse);

                if (i % 3 == 0)
                {
                    var additionalWall = int.Parse(Console.ReadLine());
                    plates.Push(additionalWall);
                }

                warriorsInput.ToList().ForEach(x => warriors.Push(x));

                while (plates.Any() && warriors.Any())
                {
                    var currentWarrior = warriors.Pop();
                    var currentPlate = plates.Peek();

                    if (currentWarrior > currentPlate)
                    {
                        warriors.Push(currentWarrior - currentPlate);
                        plates.Pop();
                    }
                    else if (currentWarrior == currentPlate)
                    {
                        plates.Pop();
                    }
                    else if (currentWarrior < currentPlate)
                    {
                        plates.Pop();
                        plates.Push(currentPlate - currentWarrior);
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
