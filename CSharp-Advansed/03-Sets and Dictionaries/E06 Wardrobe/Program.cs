using System;
using System.Linq;
using System.Collections.Generic;

namespace E06_Wardrobe
{
    class Program
    {
        static void Main()
        {
            var clothesInWardrobe = new Dictionary<string, Dictionary<string, int>>();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var clothesPart = Console.ReadLine()
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var colour = clothesPart[0];
                var clothes = clothesPart[1]
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                if (!clothesInWardrobe.ContainsKey(colour))
                {
                    clothesInWardrobe[colour] = new Dictionary<string, int>();
                }

                foreach (var item in clothes)
                {
                    if (!clothesInWardrobe[colour].ContainsKey(item))
                    {
                        clothesInWardrobe[colour][item] = 0;
                    }
                    clothesInWardrobe[colour][item]++;
                }
            }

            var clothingItem = Console.ReadLine().Split();
            var colourToSearch = clothingItem[0];
            var clothesToSearch = clothingItem[1];

            foreach (var kvp in clothesInWardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var item in kvp.Value)
                {
                    var resultAfterSearch = string.Empty;

                    if (kvp.Key == colourToSearch && item.Key == clothesToSearch)
                    {
                        resultAfterSearch = " (found!)";
                    }
                    Console.WriteLine($"* {item.Key} - {item.Value}{resultAfterSearch}");
                }
            }
        }
    }
}
