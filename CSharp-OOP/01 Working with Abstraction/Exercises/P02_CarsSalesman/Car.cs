using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine)
                   : this(model, engine, -1, "n/a")
        {
        }

        public Car(string model, Engine engine, int weight)
        : this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.model}:");
            sb.Append(this.engine);
            sb.AppendLine($"  Weight: {(this.weight == -1 ? "n/a" : this.weight.ToString())}");
            sb.Append($"  Color: {this.color}");

            return sb.ToString();
        }
    }
}

