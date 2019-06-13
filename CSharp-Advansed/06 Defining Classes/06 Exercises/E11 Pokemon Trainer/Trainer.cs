namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
       
        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; private set; } = new List<Pokemon>();
        
        public void IncreaseBadges()
        {
            Badges++;
        }

        public void ReducePokemonsHealth()
        {
            this.Pokemons.ForEach(p => p.ReduceHealth());
        }

        public void RemoveDead()
        {
            this.Pokemons = this.Pokemons
                .Where(p => p.Health > 0)
                .ToList();
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
