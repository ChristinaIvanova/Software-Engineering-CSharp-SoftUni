using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class Startup
    {
        static void Main()
        {
            CarFactory carFactory = new CarFactory();
            EngineFactory engineFactory = new EngineFactory();

            CarSalesman carSalesman = new CarSalesman(carFactory, engineFactory);

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddEngine(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddCar(parameters);
            }

            List<Car> cars = carSalesman.GetCars();

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
