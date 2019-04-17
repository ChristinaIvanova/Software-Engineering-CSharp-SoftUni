using System;
using System.Linq;
using System.Collections.Generic;

namespace E01_Train
{
    class Program
    {
        static void Main()
        {
            List<int> passengersInWagons = Console.ReadLine().Split()
                .Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
           List<int> train= PassengersMovement(passengersInWagons, capacity);
            Console.WriteLine(string.Join(" ",train));
        }

        private static List<int> PassengersMovement(List<int> passengersInWagons, int capacity)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] tokens = line.Split();
                switch (tokens[0])
                {
                    case "Add":
                        passengersInWagons.Add(int.Parse(tokens[1]));
                        break;
                    default:
                        int newPassengers = int.Parse(tokens[0]);
                        for (int i = 0; i < passengersInWagons.Count; i++)
                        {
                            if (passengersInWagons[i] + newPassengers <= capacity)
                            {
                                passengersInWagons.Insert(i, newPassengers+passengersInWagons[i]);
                                passengersInWagons.RemoveAt(i + 1);
                                break;
                            }
                        }
                        break;
                }
            }
            return passengersInWagons; 
        }
    }
}
