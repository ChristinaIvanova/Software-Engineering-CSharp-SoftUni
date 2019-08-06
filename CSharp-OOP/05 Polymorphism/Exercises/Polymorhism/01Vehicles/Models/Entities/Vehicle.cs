using _01Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models.Entities
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(Double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; private set; }

        protected abstract double AirConditionConsumption { get; }

        public string Drive(double distance)
        {
            var neededFuel = distance * (this.FuelConsumption + this.AirConditionConsumption);

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
