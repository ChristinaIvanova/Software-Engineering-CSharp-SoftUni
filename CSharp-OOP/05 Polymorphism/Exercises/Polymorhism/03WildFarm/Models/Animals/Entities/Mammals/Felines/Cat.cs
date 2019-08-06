using _03WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Models.Animals.Entities.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PrefferedFoodTypes => new List<Type> { typeof(Meat), typeof(Vegetable)};

        protected override double WeightMultiplier => 0.3;

        public override string AskFood()
        {
            return "Meow";
        }
    }
}
