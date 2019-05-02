using System;
using System.Collections.Generic;

namespace L04_Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main()
        {
            var continents = new Dictionary<string, HashSet<string>>();
            var countries = new Dictionary<string, List<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new HashSet<string>();
                }

                continents[continent].Add(country);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new List<string>();
                }

                countries[country].Add(city);
            }

            foreach (var kvp in continents)
            {
                var continent = kvp.Key;
                var countriesInContinent = kvp.Value;

                Console.WriteLine($"{continent}:");
                foreach (var country in countriesInContinent)
                {
                    var cities = countries[country];

                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
