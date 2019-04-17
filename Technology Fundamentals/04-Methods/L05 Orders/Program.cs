using System;

namespace L05_Orders
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine();

            int quantity = int.Parse(Console.ReadLine());

            CalculateOrder(product, quantity);
        }

        private static void CalculateOrder(string product, int quantity)
        {
            double price = 0.0;

            switch (product)
            {
                case "coffee":
                    price = 1.5;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.4;
                    break;
                case "snacks":
                    price = 2;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{quantity*price:f2}");
        }
    }
}
