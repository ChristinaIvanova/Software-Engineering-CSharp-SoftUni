using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, int power)
            : this(model, power, -1, "n/a")
        {
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency)
        {
        }

        public string Model { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.power}");
            sb.AppendLine($"    Displacement: {(this.displacement == -1 ? "n/a" : this.displacement.ToString())}");
            sb.AppendLine($"    Efficiency: {this.efficiency}");

            return sb.ToString();
        }
    }
}
