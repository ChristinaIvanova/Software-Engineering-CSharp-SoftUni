namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int Health
        {
            get { return health; }
            private set { health = value; }
        }

        public string Element
        {
            get { return element; }
            private set { element = value; }
        }

        public void ReduceHealth()
        {
            this.Health -= 10;
        }
    }
}
