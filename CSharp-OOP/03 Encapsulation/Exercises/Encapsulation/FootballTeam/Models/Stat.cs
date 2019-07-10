using FootballTeam.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam.Models
{
    public class Stat
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int spirit;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int spirit, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Spirit = spirit;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateValue(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Spirit
        {
            get => this.spirit;
            private set
            {
                ValidateValue(value, nameof(this.Spirit));

                this.spirit = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                ValidateValue(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                ValidateValue(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                ValidateValue(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double OverallStat => (this.Endurance + this.Spirit + this.Dribble
            + this.Shooting + this.Passing) / 5.0;

        public void ValidateValue(int value, string statName)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.InavalidStatException, statName,
                    MinStatValue, MaxStatValue));
            }
        }
    }
}
