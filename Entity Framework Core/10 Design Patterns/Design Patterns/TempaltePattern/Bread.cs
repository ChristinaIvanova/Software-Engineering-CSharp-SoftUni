using System;
using System.Collections.Generic;
using System.Text;

namespace TempaltePattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public virtual void Bake()
        {
            Console.WriteLine($"Baking the Sourdough Bread. (20 minutes)");
        }

        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
