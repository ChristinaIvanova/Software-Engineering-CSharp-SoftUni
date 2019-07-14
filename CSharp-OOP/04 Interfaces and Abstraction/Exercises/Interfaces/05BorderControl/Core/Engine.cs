using _05BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05BorderControl.Core
{
    public class Engine
    {
        private readonly List<IIdentifiable> allIdentifiables;

        public Engine()
        {
            this.allIdentifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var identifableArgs = input.Split();
                
                if (identifableArgs.Length == 3)
                {
                    AddCitizen(identifableArgs);
                }
                else
                {
                    AddRobot(identifableArgs);
                }

                input = Console.ReadLine();
            }

            var filterId = Console.ReadLine();

            this.allIdentifiables
                .Where(x => x.Id.EndsWith(filterId))
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private void AddRobot(string[] identifableArgs)
        {
            var name = identifableArgs[0];
            var idNumber = identifableArgs[1];

            Robot robot = new Robot(name, idNumber);
            this.allIdentifiables.Add(robot);
        }

        private void AddCitizen(string[] identifableArgs)
        {
            var name = identifableArgs[0];
            var age = int.Parse(identifableArgs[1]);
            var idNumber = identifableArgs[2];

            Citizen citizen = new Citizen(name, age, idNumber);
            this.allIdentifiables.Add(citizen);
        }
    }
}
