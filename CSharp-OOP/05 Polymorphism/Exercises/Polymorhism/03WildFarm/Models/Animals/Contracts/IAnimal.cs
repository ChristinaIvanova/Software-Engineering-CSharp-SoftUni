using _03WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Models.Animals.Contracts
{
  public  interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskFood();

        void Feed(IFood food);
    }
}
