using _03WildFarm.Models.Animals.Contracts;
using _03WildFarm.Models.Animals.Entities;
using _03WildFarm.Models.Animals.Entities.Birds;
using _03WildFarm.Models.Animals.Entities.Mammals;
using _03WildFarm.Models.Animals.Entities.Mammals.Felines;
using _03WildFarm.Models.Foods;
using _03WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;

namespace _03WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<Animal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                var foodInput = Console.ReadLine();

                Animal animal = GetAnimal(command);
                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            var foodArgs = foodInput.Split(" ");

            var type = foodArgs[0];
            var quantity = int.Parse(foodArgs[1]);

            return this.foodFactory.ProduceFood(type, quantity);
        }

        private Animal GetAnimal(string command)
        {
            var animalArgs = command.Split(" ");

            var type = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);

            Animal animal;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                var livingRegion = animalArgs[3];

                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }

                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    var breed = animalArgs[4];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }

                    else
                    {
                        throw new InvalidOperationException("Invalid animal type");
                    }
                }
            }

            this.animals.Add(animal);

            return animal;
        }
    }
}
