using System;

namespace E08_Threeuple
{
    class Program
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine()
                 .Split(" ", 4);

            string names = firstInput[0] + " " + firstInput[1];
            string street = firstInput[2];
            string address = firstInput[3];

            var firstTuple = new Threeuple<string, string, string>(names, street, address);

            string[] secondInput = Console.ReadLine()
                .Split();

            string personName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            string condition = secondInput[2];

            var secondTuple = new Threeuple<string, int, string>(personName, litersOfBeer, condition);

            string[] thirdInput = Console.ReadLine()
                .Split();

            string name = thirdInput[0];
            double number = double.Parse(thirdInput[1]);
            string bank = thirdInput[2];

            var thirdTuple = new Threeuple<string, double, string>(name, number, bank);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
