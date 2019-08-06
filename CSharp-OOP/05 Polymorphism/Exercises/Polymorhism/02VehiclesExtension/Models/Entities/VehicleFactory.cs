using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension.Models.Entities
{
   public class VehicleFactory
    {
        public Vehicle Produce(string type, double fuel, double consumption, int capacity)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle= new Car(fuel, consumption, capacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuel, consumption, capacity);
            }
            else
            {
                vehicle = new Bus(fuel, consumption, capacity);
            }

            return vehicle;
        }
    }
}
