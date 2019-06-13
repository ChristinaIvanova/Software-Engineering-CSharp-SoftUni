using System;
using System.Collections.Generic;
using System.Text;

namespace E07_Speed_Racing
{
    class Car
    {
        private string model;
        private double fuel;
        private double fuelConsumption;
        private int traveledDistance;

        public Car(string model, double fuel, double fuelConsumption)
        {
            this.Model = model;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public int Distance
        {
            get { return traveledDistance; }
            set { traveledDistance = value; }
        }

        public bool CanGoOnTravel(int distance)
        {
            if (FuelConsumption * distance <= Fuel)
            {
                Distance += distance;
                Fuel-=FuelConsumption*distance;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{model} {Fuel:f2} {Distance}"; 
        }
    }
}
