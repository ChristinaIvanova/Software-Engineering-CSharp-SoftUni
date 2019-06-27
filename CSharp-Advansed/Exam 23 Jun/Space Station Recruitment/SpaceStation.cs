using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.astronauts.Count;
            }
        }

        public void Add(Astronaut astronaut)
        {

            if (this.Count < this.Capacity)
            {
                this.astronauts.Add(astronaut);
            }

        }

        public bool Remove(string name)
        {
            var existing = this.astronauts.FirstOrDefault(x => x.Name == name);

            if (existing != null)
            {
                this.astronauts.Remove(existing);
                return true;
            }
            return false;

        }

        public Astronaut GetOldestAstronaut()
        {
            return this.astronauts.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.astronauts.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var item in this.astronauts)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
