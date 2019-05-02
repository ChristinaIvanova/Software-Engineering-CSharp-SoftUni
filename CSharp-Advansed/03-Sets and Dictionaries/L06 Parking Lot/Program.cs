using System;
using System.Collections.Generic;

namespace L06_Parking_Lot
{
    class Program
    {
        static void Main()
        {
            var cars = new HashSet<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(new[] { ',', ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var car = tokens[1];

                switch (command)
                {
                    case "IN":
                        cars.Add(car);
                        break;
                    case "OUT":
                        cars.Remove(car);
                        break;
                }

                input = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }

        }
    }
}
