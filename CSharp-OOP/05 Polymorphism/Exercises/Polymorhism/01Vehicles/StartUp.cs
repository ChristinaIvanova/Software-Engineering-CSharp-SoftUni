using _01Vehicles.Models.Entities;
using System;

namespace _01Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            var carArgs = Console.ReadLine().Split(" ");

            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption);

            var truckArgs = Console.ReadLine().Split(" ");

            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            var countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                var commandArgs = Console.ReadLine().Split(" ");

                var command = commandArgs[0];
                var type = commandArgs[1];
                var value = double.Parse(commandArgs[2]);

                switch (type)
                {
                    case "Car":
                        ExecuteCommand(car, command, value);
                        break;
                    case "Truck":
                        ExecuteCommand(truck, command, value);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
