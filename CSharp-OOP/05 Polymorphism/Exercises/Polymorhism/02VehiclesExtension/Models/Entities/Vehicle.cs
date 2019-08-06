using _02VehiclesExtension.Exceptions;
using _02VehiclesExtension.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension.Models.Entities
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        public Vehicle(Double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public int TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            var neededFuel = distance * this.FuelConsumption;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidRefuelingAmount);
            }
            var totalFuelAmount = fuel + this.FuelQuantity;

            if (totalFuelAmount > this.TankCapacity)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidFuelAmount, fuel));
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
