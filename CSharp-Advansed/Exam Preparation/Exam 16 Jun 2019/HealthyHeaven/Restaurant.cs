using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.Data = new List<Salad>();
        }

        public string Name { get; private set; }

        public List<Salad> Data { get; private set; }

        public void Add(Salad salad)
        {
            this.Data.Add(salad);
        }

        public bool Buy(string name)
        {
            var existing = this.Data.FirstOrDefault(x => x.Name == name);

            if (existing != null)
            {
                this.Data.Remove(existing);
                return true;
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            // int min = this.Data.Min(x => x.GetTotalCalories());
            // return this.Data.FirstOrDefault(x => x.GetTotalCalories() == min);
            // return this.Data.OrderBy(x => x.Vegetables.Sum(y => y.Calories)).FirstOrDefault();
            return this.Data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public string GenerateMenu()
        {
            var menu = new StringBuilder();

            menu.AppendLine($"{Name} have {this.Data.Count} salads:");
            if (this.Data.Any())
            {
                foreach (var salad in Data)
                {
                    menu.Append(salad.ToString());
                }
            }


            return menu.ToString().TrimEnd();
        }
    }
}
