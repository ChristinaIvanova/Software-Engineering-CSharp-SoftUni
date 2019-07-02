using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gold: TreasureItem
    {
        public Gold(string item, long amount )
        {
            this.Item = item;
            this.Amount = amount;
        }
    }
}
