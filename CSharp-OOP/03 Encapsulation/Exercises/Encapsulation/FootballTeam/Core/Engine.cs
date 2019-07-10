using FootballTeam.Exceptions;
using FootballTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam.Core
{
    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    var commandArgs = command
                        .Split(";");

                    var commandType = commandArgs[0];
                    var teamName = commandArgs[1];

                    if (commandType == "Team")
                    {
                        AddNewTeam(teamName);
                    }
                    else if (commandType == "Add")
                    {
                        AddPlayerToTeam(commandArgs, teamName);
                    }
                    else if (commandType == "Remove")
                    {
                        RemovePlayerFromTeam(commandArgs, teamName);
                    }
                    else if (commandType == "Rating")
                    {
                        ReportRating(teamName);
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                command = Console.ReadLine();
            }
        }


        private void AddNewTeam(string teamName)
        {
            var team = new Team(teamName);
            this.teams.Add(team);
        }

        private void AddPlayerToTeam(string[] commandArgs, string teamName)
        {
            ValidateTeam(teamName);

            var playerName = commandArgs[2];
            Stat stat = CreateStat(commandArgs);

            var player = new Player(playerName, stat);

            var teamToUpdate = this.teams.FirstOrDefault(p => p.Name == teamName);

            teamToUpdate.AddPlayer(player);
        }

        private void RemovePlayerFromTeam(string[] commandArgs, string teamName)
        {
            ValidateTeam(teamName);

            var playerName = commandArgs[2];

            var teamToUpdate = this.teams.FirstOrDefault(t => t.Name == teamName);
            teamToUpdate.RemovePlayer(playerName);
        }

        private void ReportRating(string teamName)
        {
            ValidateTeam(teamName);

            var teamToShow = this.teams.FirstOrDefault(t => t.Name == teamName);

            Console.WriteLine(teamToShow);
        }

        private void ValidateTeam(string team)
        {
            var existingTeam = this.teams.FirstOrDefault(t => t.Name == team);

            if (existingTeam == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.MissingTeamException, team));
            }
        }

        private static Stat CreateStat(string[] commandArgs)
        {
            var endurance = int.Parse(commandArgs[3]);
            var spirit = int.Parse(commandArgs[4]);
            var dribble = int.Parse(commandArgs[5]);
            var passing = int.Parse(commandArgs[6]);
            var shooting = int.Parse(commandArgs[7]);

            var stat = new Stat(endurance, spirit, dribble, passing, shooting);
            return stat;
        }
    }
}

