using System;
using System.Linq;
using System.Collections.Generic;

namespace E12_Cups_and_Bottles
{
    class Program
    {
        static void Main()
        {
            var cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var bottlesCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(bottlesCapacity);

            var wastedWater = 0;
            bool isEmpty = false;

            while (!isEmpty)
            {
                if (bottles.Count == 0 || cups.Count == 0)
                {
                    isEmpty = true;
                    continue;
                }

                var cup = cups.Peek();
                while (cup > 0)
                {

                    var bottle = bottles.Pop();
                    cup -= bottle;
                }

                cups.Dequeue();
                wastedWater += Math.Abs(cup);
            }

            if (bottles.Any())
            {
                var bottlesLeft = string.Join(" ", bottles);
                Console.WriteLine($"Bottles: {bottlesLeft}");
            }
            else if (cups.Any())
            {
                var cupsLeft = string.Join(" ", cups);
                Console.WriteLine($"Cups: {cupsLeft}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
