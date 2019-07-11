using System;
using System.Collections.Generic;
using System.Text;

namespace _01ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                ValidateParameter(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateParameter(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                ValidateParameter(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        public double GetVolume()
        {
            return this.length * this.height * this.width;
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.length * this.width) + GetLateralSurfaceArea();
        }

        private void ValidateParameter(double value, string parameter)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameter} cannot be zero or negative.");
            }
        }
    }
}
