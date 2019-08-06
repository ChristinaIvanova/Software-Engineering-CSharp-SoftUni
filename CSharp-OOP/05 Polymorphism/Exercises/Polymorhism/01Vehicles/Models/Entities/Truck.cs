using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models.Entities
{
    public class Truck : Vehicle
    {
        private const double wastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AirConditionConsumption => 1.6;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= fuel * wastedFuel;
        }
    }
}
