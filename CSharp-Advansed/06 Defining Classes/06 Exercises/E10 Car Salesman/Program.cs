namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var countEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < countEngines; i++)
            {
                var engineArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Engine engine = null;

                var model = engineArgs[0];
                var power = int.Parse(engineArgs[1]);

                if (engineArgs.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                else if (engineArgs.Length == 4)
                {
                    var displacement = int.Parse(engineArgs[2]);
                    var efficiency = engineArgs[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    bool isDisplacement = int.TryParse(engineArgs[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                        var efficiency = engineArgs[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }

                engines.Add(engine);
            }

            var countCarsInfo = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCarsInfo; i++)
            {
                var carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = null;

                var model = carArgs[0];
                Engine engine = engines.FirstOrDefault(e => e.Type == carArgs[1]);

                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 4)
                {
                    var weight = int.Parse(carArgs[2]);
                    var color = carArgs[3];

                    car = new Car(model, engine, weight, color);
                }
                else
                {
                    bool isWeight = int.TryParse(carArgs[2], out int weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        var color = carArgs[2];
                        car = new Car(model, engine, color);
                    }
                }

                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}


