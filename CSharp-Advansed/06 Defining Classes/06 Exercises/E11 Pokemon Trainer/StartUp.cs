namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var trainers = new List<Trainer>();

            var input = Console.ReadLine();

            while (input != "Tournament")
            {
                var tokens = input
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var element = tokens[2];
                var health = int.Parse(tokens[3]);

                var pokemon = new Pokemon(pokemonName, element, health);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                trainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input!="End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p=>p.Element==input))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.ReducePokemonsHealth();
                        trainer.RemoveDead();
                    }
                }

                input = Console.ReadLine();
            }

            trainers
                .OrderByDescending(t => t.Badges)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
