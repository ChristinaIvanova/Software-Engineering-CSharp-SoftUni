using System;
using System.Linq;
using System.Collections.Generic;

namespace E06_Auto_Repair_and_Service
{
    class Program
    {
        static void Main()
        {
            var carsInService = Console.ReadLine().Split();
            var waitingCars = new Queue<string>(carsInService);

            var servedCars = new Stack<string>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input.Split("-");
                var command = tokens[0];

                if (command == "Service")
                {
                    if (waitingCars.Any())
                    {
                        var servedCar = waitingCars.Dequeue();
                        servedCars.Push(servedCar);

                        Console.WriteLine($"Vehicle {servedCar} got served.");
                    }
                }
                else if (command == "CarInfo")
                {
                    var carToLookFor = tokens[1];

                    if (waitingCars.Contains(carToLookFor))
                    {
                        Console.WriteLine($"Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine($"Served.");
                    }
                }
                else if (command == "History")
                {
                    var currentServed = string.Join(", ", servedCars);
                    Console.WriteLine(currentServed);
                }

                input = Console.ReadLine();
            }

            if (waitingCars.Any())
            {
                var carsForService = string.Join(", ", waitingCars);
                Console.WriteLine($"Vehicles for service: {carsForService}");
            }

            var servedVechiles = string.Join(", ", servedCars);
            Console.WriteLine($"Served vehicles: {servedVechiles}");
        }
    }
}
