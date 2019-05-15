using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Car_Engine_and_Tires
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        private Engine engine;
        private Tire[] tires;

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public Car(string make, string model, int year,
            double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car()
            : this("VW", "Golf", 2025, 200, 10)
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Car make must be more than 2 symbols");
                }

                this.make = value;
            }

        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Car model must be more than 2 symbols and less than 20 symbols");
                }

                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value < 1960 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Car year must be between 1960 and {DateTime.Now.Year}");
                }

                this.year = value;
            }
        }
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.engine), "Engine cannot be null");
                }

                this.engine = value;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.tires), "Tires cannot be null");
                }

                this.tires = value;
            }
        }
    }
}
