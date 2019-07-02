using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class TreasureItemFactory
    {
        public TreasureItem Create(string piece, long amount)
        {
            if (piece.Length == 3)
            {
                return new Cash(piece, amount);
            }
            else if (piece.ToLower().EndsWith("gem"))
            {
                return new Gem(piece, amount);
            }
            else if (piece.ToLower() == "gold")
            {
                return new Gold(piece, amount);
            }
            return new TreasureItem();
        }
    }
}
