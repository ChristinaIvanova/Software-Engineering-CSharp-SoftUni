using _02VehiclesExtension.Models;
using _02VehiclesExtension.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02VehiclesExtension
{
    public class StartUp
    {
        static void Main()
        {
            var vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                var vehicleArgs = Console.ReadLine().Split(" ");
                Vehicle vehicle = CreatVehicle(vehicleArgs);

                vehicles.Add(vehicle);
            }

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
                        Car car = (Car)vehicles.FirstOrDefault(x => x.GetType().Name == "Car");
                        ExecuteCommand(car, command, value);
                        break;
                    case "Truck":
                        Truck truck = (Truck)vehicles.FirstOrDefault(x => x.GetType().Name == "Truck");
                        ExecuteCommand(truck, command, value);
                        break;
                    case "Bus":
                        Bus bus = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == "Bus");
                        ExecuteCommand(bus, command, value);
                        break;
                }
            }

            vehicles.ForEach(Console.WriteLine);
        }

        private static Vehicle CreatVehicle(string[] vehicleArgs)
        {
            var type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            int tankCapacity = int.Parse(vehicleArgs[3]);

            var factory = new VehicleFactory();
            return factory.Produce(type, fuelQuantity, fuelConsumption, tankCapacity);
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(value);
                    }
                    catch (Exception msg)
                    {
                        Console.WriteLine(msg.Message);
                    }

                    break;
                case "DriveEmpty":
                    Console.WriteLine(((Bus)vehicle).DriveEmpty(value));
                    break;
            }
        }
    }
}
