using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
        public override decimal CalculateTotalPrice()
        {
            var total = 0m;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var gift in this.gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
