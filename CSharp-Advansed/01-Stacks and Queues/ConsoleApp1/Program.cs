using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var number = queue.Dequeue();

            Console.WriteLine(number);
            var a=queue.Peek();
            Console.WriteLine(a);
        }
    }
}
