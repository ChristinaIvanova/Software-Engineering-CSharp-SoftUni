using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Remotion.Linq.Clauses;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;
using Formatting = Newtonsoft.Json.Formatting;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context
                .Genres
                .Where(g => genreNames.Contains(g.Name))
                .OrderByDescending(g => g.Games.Sum(p => p.Purchases.Count))
                .ThenBy(g => g.Id)
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(gg => gg.Purchases.Any())
                        .Select(gg => new
                        {
                            Id = gg.Id,
                            Title = gg.Name,
                            Developer = gg.Developer.Name,
                            Tags = string.Join(", ", gg.GameTags.Select(t => t.Tag.Name)),
                            Players = gg.Purchases.Count
                        })
                        .OrderByDescending(gg => gg.Players)
                        .ThenBy(gg => gg.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Sum(p => p.Purchases.Count)
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(games, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var storeTypeValue = Enum.Parse<PurchaseType>(storeType);

            var users = context
                .Users
                .Select(u => new UserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == storeTypeValue)
                        .Select(p => new PurchaseDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = u.Cards.SelectMany(c => c.Purchases).Where(p => p.Type == storeTypeValue).Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(UserDto[]),
                new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}