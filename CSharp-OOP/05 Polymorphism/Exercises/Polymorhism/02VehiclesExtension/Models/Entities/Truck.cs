using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension.Models.Entities
{
    public class Truck : Vehicle
    {
        private const double aircoConsumption = 1.6;
        private const double wastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + aircoConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= fuel * wastedFuel;
        }
    }
}
