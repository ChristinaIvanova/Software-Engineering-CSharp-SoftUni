using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> data;

        public Arena(string name)
        {
            this.Name = name;
            this.data = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }


        public void Add(Gladiator gladiator)
        {
            this.data.Add(gladiator);
        }

        public void Remove(string name)
        {
            var existing = data.FirstOrDefault(x => x.Name == name);

            if (existing != null)
            {
                this.data.Remove(existing);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.data
                .OrderByDescending(x => x.GetStatPower())
                .FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.data
                .OrderByDescending(x => x.GetWeaponPower())
                .FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.data
                .OrderByDescending(x => x.GetTotalPower())
                .FirstOrDefault();
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
