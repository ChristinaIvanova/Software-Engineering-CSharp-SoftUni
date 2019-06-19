using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        public Salad(string name)
        {
            this.Name = name;
            this.Vegetables = new List<Vegetable>();
        }

        public string Name { get; private set; }

        public List<Vegetable> Vegetables { get; private set; }

        public int GetTotalCalories()
        {
            return this.Vegetables.Sum(x => x.Calories);
        }

        public int GetProductCount()
        {
          // return this.Vegetables.Select(x => x.Name).Count();
           return this.Vegetables.Count;
        }

        public void Add(Vegetable product)
        {
            this.Vegetables.Add(product);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var vegetable in this.Vegetables)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
