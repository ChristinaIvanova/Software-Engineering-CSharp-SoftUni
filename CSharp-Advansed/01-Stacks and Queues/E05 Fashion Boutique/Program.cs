using System;
using System.Linq;
using System.Collections.Generic;

namespace E05_Fashion_Boutique
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var capacity = int.Parse(Console.ReadLine());
            
            var clothes = new Stack<int>(input);

            var result = clothes.Pop();
            var counterOfRacks = 1;

            while (clothes.Any())
            {
                var nextPiece = clothes.Peek();

                if (result + nextPiece <= capacity)
                {
                    clothes.Pop();
                    result += nextPiece;
                }
                
                else 
                {
                    result = 0;
                    counterOfRacks++;
                }
            }

            Console.WriteLine(counterOfRacks);
        }
    }
}
