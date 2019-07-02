using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        private TreasureItemFactory treasureFactory;
        private List<TreasureItem> bag;
        private long capacity;
        private long current;

        public Bag(long capacity, TreasureItemFactory treasureFactory)
        {
            this.capacity = capacity;
            this.bag = new List<TreasureItem>();
            this.treasureFactory = treasureFactory;
        }

        public long GoldValue => bag.Where(i => i is Gold).Sum(i => i.Amount);

        public long GemValue => bag.Where(i => i is Gem).Sum(i => i.Amount);

        public long CashValue => bag.Where(i => i is Cash).Sum(i => i.Amount);

        public void Fill(string piece, long amount)
        {
            TreasureItem item = this.treasureFactory.Create(piece, amount);

            if (capacity >= current + item.Amount)
            {
                if (item is Gold)
                {
                    if (GoldValue + item.Amount >= GemValue)
                    {
                        this.bag.Add(item);
                    }
                }
                else if (item is Gem)
                {
                    if (GemValue + item.Amount <= GoldValue)
                    {
                        this.bag.Add(item);
                    }
                }
                else if (item is Cash)
                {
                    if (CashValue + item.Amount <= GemValue)
                    {
                        this.bag.Add(item);
                    }
                }

                current = GoldValue + GemValue + CashValue;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var treasuresInBag = bag.GroupBy(t => t.GetType().Name)
                .ToDictionary(x => x.Key, x => x.ToList())
                .OrderByDescending(x => x.Value.Sum(i => i.Amount));

            foreach (var treasure in treasuresInBag)
            {
                sb.AppendLine($"<{treasure.Key}> ${treasure.Value.Sum(i => i.Amount)}");

                var items = treasure.Value.GroupBy(x => x.Item)
                     .Select(x => new
                     {
                         Item = x.Key,
                         Amount = x.Sum(y => y.Amount)
                     })
                    .ToList();

                foreach (var kvp in items.OrderByDescending(x => x.Item).ThenBy(x => x.Amount))
                {
                    sb.AppendLine($"##{kvp.Item} - {kvp.Amount}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
