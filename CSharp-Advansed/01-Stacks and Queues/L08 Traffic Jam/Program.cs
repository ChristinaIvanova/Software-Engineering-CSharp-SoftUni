using System;
using System.Collections.Generic;

namespace L08_Traffic_jam
{
    class Program
    {
        static void Main()
        {
            var countPerGreenLight = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            var totalPassed = 0;

            while (true)
            {
                var currentLine = Console.ReadLine();

                if (currentLine == "end")
                {
                    Console.WriteLine($"{totalPassed} cars passed the crossroads.");
                    break;
                }

                if (currentLine != "green")
                {
                    cars.Enqueue(currentLine);
                }
                else
                {
                    var carToPass = Math.Min(countPerGreenLight, cars.Count);

                    for (int i = 0; i < carToPass; i++)
                    {
                        var currentCar = cars.Dequeue();
                        Console.WriteLine($"{currentCar} passed!");

                        totalPassed++;
                    }
                }
            }
        }
    }
}
