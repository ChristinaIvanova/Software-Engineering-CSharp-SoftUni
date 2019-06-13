using System;
using System.Collections.Generic;
using System.Text;

namespace E08_Raw_Data
{
    class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
        public double Pressure
        {
            get { return pressure; }
            private set { pressure = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

    }
}
