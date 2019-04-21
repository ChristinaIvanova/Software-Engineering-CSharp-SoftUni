using System;
using System.Linq;
using System.Collections.Generic;

namespace E07_Truck_Tour
{
    class Program
    {
        static void Main()
        {
            var pumpsCount = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var pump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(pump);
            }

            var truckFuel = 0;
            var startIndex = 0;
            var loop = pumps.Count;

            for (int i = 0; i < loop && startIndex < pumps.Count; i++)
            {
                var currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                truckFuel += currentPump[0] - currentPump[1];

                if (truckFuel < 0)
                {
                    startIndex = i + 1;
                    loop++;
                    truckFuel = 0;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
