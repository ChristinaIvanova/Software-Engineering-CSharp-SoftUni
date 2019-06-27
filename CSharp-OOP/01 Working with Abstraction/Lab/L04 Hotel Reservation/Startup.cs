using System;

namespace L04HotelReservation
{
    class Startup
    {
        static void Main()
        {
            var priceCalculator = new PriceCalculator();

            var reservationArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(reservationArgs[0]);
            var days = int.Parse(reservationArgs[1]);
            var season 
            var discount = reservationArgs[3];

            if (season==Season.Spring)
            {

            }
            priceCalculator.CalculatePrice(pricePerDay, days, season, discount);
        }
    }
}
