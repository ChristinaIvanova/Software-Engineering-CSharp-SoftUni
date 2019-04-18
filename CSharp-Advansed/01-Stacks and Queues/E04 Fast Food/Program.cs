using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_Fast_Food
{
    class Program
    {
        static void Main()
        {
            var allFood = int.Parse(Console.ReadLine());
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var orders = new Queue<int>(input);
            var biggestOrder = orders.Max();

            for (int i = 0; i < input.Length; i++)
            {
                var nextOrder = orders.Peek();

                if (allFood - nextOrder >= 0)
                {
                    orders.Dequeue();
                    allFood -= nextOrder;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);

            if (orders.Count != 0 )
            {
                var leftOrders = string.Join(" ", orders);
                Console.WriteLine($"Orders left: {leftOrders}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
