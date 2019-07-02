using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
   public class Runner
    {
        private List<Car> cars;

        public Runner()
        {
            this.cars = new List<Car>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                   ? .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];

            int tireIndex = 0;

            for (int j = 5; j < parameters.Length; j += 2)
            {
                double tirePressure = double.Parse(parameters[j]);
                int tireAge = int.Parse(parameters[j + 1]);

                Tire tire = new Tire(tirePressure, tireAge);
                tires[tireIndex] = tire;

                tireIndex++;
            }

            Car car = new Car(model, engine, cargo, tires);
            return car;
        }
    }
}
