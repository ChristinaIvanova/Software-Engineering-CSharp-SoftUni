using FootballTeam.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeam.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public int Rating => (int)Math.Round(this.players.Average(p => p.OverallSkill), 0);

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove != null)
            {
                this.players.Remove(playerToRemove);
            }
            else
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.MissingPlayerException, playerName, this.Name));
            }
        }

        public override string ToString()
        {
            if (this.players.Count == 0)
            {
                return $"{this.Name} - 0";
            }

            return $"{this.Name} - {this.Rating}";
        }
    }
}
