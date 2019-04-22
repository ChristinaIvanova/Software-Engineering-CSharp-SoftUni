using System;

namespace _0001Е_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int countWagons = int.Parse(Console.ReadLine());
            
            int[] peopleInWagons = new int[countWagons];
            int peopleInTrain = 0;
            string wagon = null;
            
            for (int i = 0; i < peopleInWagons.Length; i++)
            {
                peopleInWagons[i] = int.Parse(Console.ReadLine());
                peopleInTrain += peopleInWagons[i];
                wagon = string.Join(' ',peopleInWagons);
                
            }
            
            Console.WriteLine($"{wagon}{Environment.NewLine}{peopleInTrain}");
        }
    }
}
