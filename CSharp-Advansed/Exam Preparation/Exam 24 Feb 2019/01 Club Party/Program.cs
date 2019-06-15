using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Club_Party
{

    class Program
    {
        static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());

            var halls = new Queue<string>();
            var reservations = new Queue<int>();

            var removedHalls = new Dictionary<string, List<int>>();
            var readyReservations = new List<int>();

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var currentCapacity = capacity;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var isNumeric = int.TryParse(input[i], out int people);

                if (!isNumeric)
                {
                    halls.Enqueue(input[i]);
                }

                if (isNumeric && halls.Any())
                {
                    reservations.Enqueue(people);
                }

                if (halls.Any() && reservations.Any())
                {
                    var currentHall = halls.Peek();
                    var currentReservation = reservations.Peek();

                    if (currentReservation < currentCapacity)
                    {
                        currentCapacity -= currentReservation;
                        reservations.Dequeue();

                        readyReservations.Add(currentReservation);
                    }
                    else if (currentReservation > currentCapacity)
                    {
                        halls.Dequeue();
                        currentCapacity = capacity;
                        removedHalls.Add(currentHall, readyReservations);
                        readyReservations = new List<int>();
                    }

                    else if (currentReservation == currentCapacity)
                    {
                        reservations.Dequeue();
                        readyReservations.Add(currentReservation);

                        halls.Dequeue();
                        currentCapacity = capacity;
                        removedHalls.Add(currentHall, readyReservations);
                        readyReservations = new List<int>();
                    }

                    if (!halls.Any() && reservations.Any())
                    {
                        reservations.Dequeue();
                    }
                }
            }

            foreach (var hall in removedHalls)
            {
                Console.WriteLine($"{hall.Key} -> {string.Join(", ", hall.Value)}");
            }
        }
    }
}
