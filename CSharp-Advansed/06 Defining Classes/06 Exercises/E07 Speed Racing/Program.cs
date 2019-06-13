namespace E07_Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var cars = new List<Car>();
            var countCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCars; i++)
            {
                var carArgs = Console.ReadLine()
                    .Split();

                var model = carArgs[0];
                var fuel = double.Parse(carArgs[1]);
                var fuelConsumption = double.Parse(carArgs[2]);

                var car = new Car(model, fuel, fuelConsumption);
                cars.Add(car);
            }

            var input = Console.ReadLine();

            while (input!="End")
            {
                var tokens = input.Split();

                var model = tokens[1];
                var distance = int.Parse(tokens[2]);

                var car = cars.FirstOrDefault(x => x.Model == model);

                if (!car.CanGoOnTravel(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                input = Console.ReadLine();
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
