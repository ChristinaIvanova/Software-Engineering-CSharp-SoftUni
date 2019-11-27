using System;
using System.Collections.Generic;
using System.Text;

namespace TempaltePattern
{
    public class Sourdough : Bread
    {
        private const string bakingTime = "20 minutes";
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
    }
}
