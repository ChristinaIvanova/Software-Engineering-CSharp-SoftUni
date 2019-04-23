using System;
using System.Linq;
using System.Collections.Generic;

namespace E11_Key_Revolver
{
    class Program
    {
        static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var sizeGun = int.Parse(Console.ReadLine());
            var bulletSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse);
            var lockSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse);
            var intelligence = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletSequence);
            var locks = new Queue<int>(lockSequence);

            var counterBullets = 0;

            while (locks.Any())
            {
                if (bullets.Any())
                {
                    var nextBullet = bullets.Pop();
                    var nextLock = locks.Peek();

                    if (nextBullet <= nextLock)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    counterBullets++;

                    if (counterBullets % sizeGun == 0 && bullets.Any())
                    {
                        Console.WriteLine("Reloading!");
                    }

                }
                else
                {
                    break;
                }
            }

            if (locks.Any())
            {
                var locksLeft = locks.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
            else
            {
                var bulletsLeft = bullets.Count;
                var moneyEarned = intelligence - counterBullets * bulletPrice;
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
