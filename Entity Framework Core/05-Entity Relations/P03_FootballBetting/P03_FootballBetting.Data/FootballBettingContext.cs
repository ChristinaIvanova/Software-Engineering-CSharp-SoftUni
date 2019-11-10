using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        public FootballBettingContext (DbContextOptions options) 
            : base(options)
        {
        }

        public FootballBettingContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(t => t.PrimaryKitColor)
                    .WithMany(pr => pr.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                    .WithMany(s => s.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Town)
                    .WithMany(to => to.Teams)
                    .HasForeignKey(t => t.TownId);

                entity.HasMany(t => t.HomeGames)
                    .WithOne(g => g.HomeTeam)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.AwayGames)
                    .WithOne(g => g.AwayTeam)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.Players)
                    .WithOne(p => p.Team)
                    .HasForeignKey(t => t.PlayerId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(pl => pl.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(pl => pl.PositionId);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId);

                entity.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId);
            });


            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId);

                entity.HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasMany(c => c.Towns)
                    .WithOne(t => t.Country)
                    .HasForeignKey(t => t.CountryId);
            });
        }
    }
}
