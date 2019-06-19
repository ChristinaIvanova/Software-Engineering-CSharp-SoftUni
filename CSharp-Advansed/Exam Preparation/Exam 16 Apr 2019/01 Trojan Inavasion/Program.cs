using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Trojan_Inavasion
{
    class Program
    {
        static void Main()
        {
            var wavesCount = int.Parse(Console.ReadLine());

            var platesArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var plates = new Queue<int>(platesArgs);
            var warriors = new Stack<int>();



            for (int i = 1; i <= wavesCount; i++)
            {
                var input = Console.ReadLine();

                if (i % 3 == 0)
                {
                    var additionalPlate = Console.ReadLine();
                    plates.Enqueue(int.Parse(additionalPlate));
                }

                var wave = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

                wave.ToList().ForEach(warriors.Push);

                var plate = plates.Peek();
                var warrior = 0;

                while (plate > 0 && warriors.Any())
                {
                    warrior = warriors.Pop();
                    plate -= warrior;
                }

                plates.Dequeue();

                if (plate < 0)
                {
                    warriors.Push(Math.Abs(plate));
                }
                
                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (warriors.Any())
            {

                var leftWarriors = string.Join(", ", warriors);

                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {leftWarriors}");
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
