using System;
using System.Collections.Generic;

namespace L07_Hot_potato
{
    class Program
    {
        static void Main()
        {
            var allChildren = Console.ReadLine().Split();
            Queue<string> children = new Queue<string>(allChildren);

            var number = int.Parse(Console.ReadLine());
            var counter = 1;

            while (children.Count > 1)
            {
                var currentChild = children.Dequeue();

                if (counter % number != 0)
                {
                    children.Enqueue(currentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                }

                counter++;
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
