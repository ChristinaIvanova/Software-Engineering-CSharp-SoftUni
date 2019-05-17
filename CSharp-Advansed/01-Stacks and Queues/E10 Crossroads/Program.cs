using System;
using System.Linq;
using System.Collections.Generic;

namespace _10
{
    class Program
    {
        static void Main()
        {
            var green = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var trafficQueue = new Queue<string>();

            var input = Console.ReadLine();
            var totalCarsPassed = 0;

            while (input != "END")
            {
                if (input != "green")
                {
                    trafficQueue.Enqueue(input);
                }
                else
                {
                    string car = string.Empty;
                    var currentGreen = green;

                    while (trafficQueue.Any() && currentGreen > 0)
                    {
                        car = trafficQueue.Dequeue();
                        currentGreen -= car.Length;
                        totalCarsPassed++;
                    }

                    var leftWindowTime = freeWindow + currentGreen;
                    if (leftWindowTime < 0)
                    {
                        var indexOfHit = car.Length + leftWindowTime;
                        var symbolOfHit = car[indexOfHit];
                        Crash(car, symbolOfHit);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void Crash(string car, char symbolOfHit)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{car} was hit at {symbolOfHit}.");
            Environment.Exit(0);
        }
    }
}
