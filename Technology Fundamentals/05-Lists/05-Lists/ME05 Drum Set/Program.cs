using System;
using System.Linq;
using System.Collections.Generic;

namespace ME05_Drum_Set
{
    class Program
    {
        static void Main()
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialiDrumSet = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            List<int> drumSet = new List<int>();
            for (int i = 0; i < initialiDrumSet.Count; i++)
            {
                drumSet.Add(initialiDrumSet[i]);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Hit it again, Gabsy!")
                {
                    break;
                }
                int power = int.Parse(input);
                //drumSet = initialiDrumSet.Select(x => x - power).ToList();
                for (int i = 0; i < initialiDrumSet.Count; i++)
                {
                    if (drumSet[i] - power > 0)
                    {
                        drumSet.Insert(i, drumSet[i] - power);
                        drumSet.RemoveAt(i + 1);
                    }

                    else if (drumSet[i] - power <= 0 && savings >= (initialiDrumSet[i] * 3))
                    { 
                        drumSet.Insert(i,initialiDrumSet[i]);
                        drumSet.RemoveAt(i+1);
                        savings -= 3 * initialiDrumSet[i];
                    }

                    else if (drumSet[i] - power <= 0 && savings < (initialiDrumSet[i] * 3))
                    {
                        drumSet.RemoveAt(i);
                        initialiDrumSet.RemoveAt(i);
                        i -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
