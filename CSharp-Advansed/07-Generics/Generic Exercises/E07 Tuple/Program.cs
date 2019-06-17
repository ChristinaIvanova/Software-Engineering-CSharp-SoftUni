using System;

namespace E07Tuple
{
    class Program
    {
        static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string names = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            var firstTuple = new Tuple<string, string>(names, address);

            string[] secondInput = Console.ReadLine()
                .Split();

            string personName = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            var secondTuple = new Tuple<string, int>(personName, litersOfBeer);

            string[] thirdInput = Console.ReadLine()
                .Split();

            int firstNumber = int.Parse(thirdInput[0]);
            double secondNumber = double.Parse(thirdInput[1]);

            var thirdTuple = new Tuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
