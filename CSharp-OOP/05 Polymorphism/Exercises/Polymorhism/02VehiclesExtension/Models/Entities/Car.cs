using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension.Models.Entities
{
    public class Car : Vehicle
    {
        private const double aicoConsumption = 0.9;

        private double carFuelQuantity;
        private double carFuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + aicoConsumption, tankCapacity)
        {
        }
    }
}
