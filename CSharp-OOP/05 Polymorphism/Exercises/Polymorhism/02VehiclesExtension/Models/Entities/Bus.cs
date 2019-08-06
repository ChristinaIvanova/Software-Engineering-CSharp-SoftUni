using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension.Models.Entities
{
    public class Bus : Vehicle
    {
        private const double aircoConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + aircoConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= aircoConsumption;
            return base.Drive(distance);
        }
    }
}
