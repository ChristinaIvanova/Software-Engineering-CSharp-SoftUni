using System;
using System.Linq;

namespace _0001L_Day_of_week
{
   public class Program
    {
       public static void Main()
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int number = int.Parse(Console.ReadLine());
            if (number>=1 && number<=7)
            {
                Console.WriteLine(daysOfWeek[number-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
