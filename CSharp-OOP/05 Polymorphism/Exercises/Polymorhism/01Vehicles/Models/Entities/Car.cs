using System;
using System.Collections.Generic;
using System.Text;

namespace _01Vehicles.Models.Entities
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AirConditionConsumption => 0.9;
    }
}
