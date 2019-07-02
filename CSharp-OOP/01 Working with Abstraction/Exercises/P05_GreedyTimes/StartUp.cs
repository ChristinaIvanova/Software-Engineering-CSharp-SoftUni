using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            var treasureFactory = new TreasureItemFactory();

            var capacity = long.Parse(Console.ReadLine());

            var safeBox = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            var bag = new Bag(capacity, treasureFactory);

            for (int i = 0; i < safeBox.Length; i += 2)
            {
                var item = safeBox[i];
                var amount = long.Parse(safeBox[i + 1]);

                bag.Fill(item, amount);
            }

            Console.WriteLine(bag.ToString());
        }
    }
}