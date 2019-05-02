using System;
using System.Linq;
using System.Collections.Generic;

namespace L03_Product_Shop
{
    class Program
    {
        static void Main()
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Revision")
                {
                    break;
                }

                var productParts = line
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var shop = productParts[0];
                var product = productParts[1];
                var price = double.Parse(productParts[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop][product] = price;
            }

            foreach (var kvp in shops)
            {
                var shop = kvp.Key;
                var products = kvp.Value;

                Console.WriteLine($"{shop}->");
                foreach (var productKvp in products)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value:f1}");
                }
            }
            var set = new SortedSet<string>();
        }
    }
}
