using System;

namespace L04HotelReservation
{
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine()
                       .Split();

            var priceCalculator = new PriceCalculator(input);
            
            Console.WriteLine(priceCalculator.GetTotalPrice().ToString("F2"));
        }
    }
}
