using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gem : TreasureItem
    {
        public Gem(string item, long amount)
        {
            this.Item = item;
            this.Amount = amount;
        }
    }
}
