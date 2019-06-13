namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        public Engine(string type, int power, int? displacement, string efficiency)
        {
            this.Type = type;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string type, int power, int? displacement)
            : this(type, power, displacement, "n/a")
        {
        }

        public Engine(string type, int power, string efficiency)
            : this(type, power, -1, efficiency)
        {
        }

        public Engine(string type, int power)
             : this(type, power, -1, "n/a")
        {
        }

        public string Type { get; set; }
        
        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"  {Type}:");
            builder.AppendLine($"    Power: {Power}");
            builder.AppendLine($"    Displacement: {(Displacement==-1? "n/a": Displacement.ToString())}");
            builder.AppendLine($"    Efficiency: {Efficiency}");

            return builder.ToString();
        }
    }
}
