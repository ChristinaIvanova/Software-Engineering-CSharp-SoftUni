using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShip
{
    class Program
    {
        static void Main()
        {
            var liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var itemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var liquids = new Queue<int>(liquidsInput);
            var items = new Stack<int>(itemsInput);

            Dictionary<string, int> ready = new Dictionary<string, int>()
            {
                {"Aluminium", 0 },
                {"Carbon fiber", 0},
                {"Glass", 0 },
                {"Lithium", 0 }
            };

            while (liquids.Any() && items.Any())
            {
                var currentLiquid = liquids.Dequeue();
                var currentItem = items.Pop();

                var result = currentLiquid + currentItem;

                var material = CreateMaterial(result);

                if (material != string.Empty)
                {
                    ready[material] += 1;
                }
                else
                {
                    items.Push(currentItem + 3);
                }
            }

            var readyCounts = ready.Where(x => x.Value > 0).ToList();

            if (readyCounts.Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            var leftLiquids = "none";
            if (liquids.Any())
            {
                leftLiquids = string.Join(", ", liquids);
            }
            Console.WriteLine($"Liquids left: {leftLiquids}");

            var leftItems = "none";
            if (items.Any())
            {
                leftItems = string.Join(", ", items);
            }
            Console.WriteLine($"Physical items left: {leftItems}");

            foreach (var kvp in ready.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        private static string CreateMaterial(int result)
        {
            var material = string.Empty;

            if (result == 25)
            {
                material = "Glass";
            }
            else if (result == 50)
            {
                material = "Aluminium";
            }
            else if (result == 75)
            {
                material = "Lithium";
            }
            else if (result == 100)
            {
                material = "Carbon fiber";
            }

            return material;
        }
    }
}
