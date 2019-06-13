namespace E08_Raw_Data
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
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArgs[0];
                var engineSpeed = int.Parse(carArgs[1]);
                var enginePower = int.Parse(carArgs[2]);
                var cargoWeight = int.Parse(carArgs[3]);
                var cargoType = carArgs[4];

                var tires = new List<Tire>();

                for (int tireCount = 5; tireCount < carArgs.Length; tireCount+=2)
                {
                    var pressure = double.Parse(carArgs[tireCount]);
                    var age =int.Parse(carArgs[tireCount + 1]);

                    var tire = new Tire(pressure, age);
                    tires.Add(tire);
                }

                var engine = new Engine(engineSpeed,enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var filter = Console.ReadLine();

            Func<List<Car>, List<Car>> filterFunc = x => filter == "fragile"
              ? cars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).ToList()
              : cars = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).ToList();

            filterFunc(cars)
                .Select(c => c.Model)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
