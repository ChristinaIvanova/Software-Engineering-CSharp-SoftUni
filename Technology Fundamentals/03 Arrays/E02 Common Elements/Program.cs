using System;
using System.Linq;
namespace _002Е_Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayFirst = Console.ReadLine().Split();
            string[] arraySecond = Console.ReadLine().Split();
            //var intersect = arraySecond.Intersect(arrayFirst);
            //Console.WriteLine(intersect);
            //foreach (var value in intersect)
            //{
            //    Console.Write($"{value} ");
            //}
            //Console.WriteLine();
            for (int i = 0; i < arraySecond.Length; i++)
            {
                for (int j = 0; j < arrayFirst.Length; j++)
                {
                    if (arraySecond[i]==arrayFirst[j])
                    {
                        Console.Write($"{arraySecond[i]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
