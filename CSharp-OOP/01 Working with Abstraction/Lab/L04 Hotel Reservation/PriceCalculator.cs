using System;
using System.Collections.Generic;
using System.Text;

namespace L04HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private Season seasonMultiplier;
        private Discount discountPercentage;

        public PriceCalculator(string[] commandArgs)
        {
            pricePerNight = decimal.Parse(commandArgs[0]);
            nights = int.Parse(commandArgs[1]);
            seasonMultiplier = Enum.Parse<Season>(commandArgs[2]);
            discountPercentage = Discount.None;

            if (commandArgs.Length == 4)
            {
                discountPercentage = Enum.Parse<Discount>(commandArgs[3]);
            }
        }

        public decimal GetTotalPrice()
        {
            decimal basePrice = pricePerNight * nights * (int)seasonMultiplier;

            return basePrice - basePrice * (decimal)discountPercentage / 100;
        }
    }
}
