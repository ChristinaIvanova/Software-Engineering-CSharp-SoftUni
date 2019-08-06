using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double fuel);
    }
}
