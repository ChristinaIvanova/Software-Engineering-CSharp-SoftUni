using System;
using System.Collections.Generic;
using System.Text;

namespace L04_Car_Engine_and_Tires
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Power must be a positive number");
                }

                this.horsePower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return this.cubicCapacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity must be a positive number");
                }

                this.cubicCapacity = value;
            }
        }
    }
}
