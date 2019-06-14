using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Socks
{
    class Program
    {
        static void Main()
        {
            var leftSocksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var rightSocksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var leftSocks = new Stack<int>(leftSocksInput);
            var rightSocks = new Queue<int>(rightSocksInput);

            var readyPairs = new List<int>();

            bool isReadyPairs = false;

            while (!isReadyPairs)
            {
                var currentLeft = leftSocks.Peek();
                var currentRight = rightSocks.Peek();

                if (currentLeft > currentRight)
                {
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                    readyPairs.Add(currentLeft + currentRight);
                }
                else if (currentRight > currentLeft)
                {
                    leftSocks.Pop();
                }
                else if (currentLeft == currentRight)
                {
                    rightSocks.Dequeue();
                    
                    currentLeft += 1;
                    leftSocks.Pop();
                    leftSocks.Push(currentLeft);
                }
                if (leftSocks.Count == 0 || rightSocks.Count == 0)
                {
                    isReadyPairs = true;
                    break;
                }
            }

            var biggestPair = readyPairs.Max();
            var pairs = string.Join(" ", readyPairs);

            Console.WriteLine(biggestPair);
            Console.WriteLine(pairs);
        }
    }
}
