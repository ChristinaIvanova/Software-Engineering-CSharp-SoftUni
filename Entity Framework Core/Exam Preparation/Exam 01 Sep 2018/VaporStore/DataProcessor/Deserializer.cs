using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var games = new List<Game>();

            var gameDtos = JsonConvert.DeserializeObject<GameDto[]>(jsonString);


            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = context.Developers.FirstOrDefault(g => g.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    context.Developers.Add(developer);
                    context.SaveChanges();
                }

                game.Developer = developer;

                var genre = context.Genres.FirstOrDefault(d => d.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    context.Genres.Add(genre);
                    context.SaveChanges();
                }

                game.Genre = genre;

                foreach (var gameDtoTag in gameDto.Tags)
                {
                    var existingTag = context.Tags.FirstOrDefault(t => t.Name == gameDtoTag);
                    if (existingTag == null)
                    {
                        existingTag = new Tag
                        {
                            Name = gameDtoTag
                        };

                        context.Tags.Add(existingTag);
                        context.SaveChanges();
                    }

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = existingTag
                    });
                }

                games.Add(game);

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var users = new List<User>();

            var usersDto = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userDto.Cards.Select(c =>
                        new Card
                        {
                            Number = c.Number,
                            Cvc = c.Cvc,
                            Type = c.Type
                        })
                        .ToList()
                };

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.AddRange(users);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var purchases = new List<Purchase>();

            var xmlSerializer = new XmlSerializer(typeof(PurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var purchasesDto = (PurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = purchaseDto.Type,
                    ProductKey = purchaseDto.ProductKey,
                    Date = DateTime.ParseExact(purchaseDto.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = context.Cards.Single(c => c.Number == purchaseDto.Card),
                    Game = context.Games.Single(g => g.Name == purchaseDto.Game)
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.AddRange(purchases);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return result;
        }
    }
}