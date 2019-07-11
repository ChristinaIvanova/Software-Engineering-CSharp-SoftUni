using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split();

                var pizzaName = pizzaArgs[1];

                var doughArgs = Console.ReadLine().Split();

                var type = doughArgs[1];
                var baking = doughArgs[2];
                var grams = double.Parse(doughArgs[3]);

                var dough = new Dough(type, baking, grams);

                var pizza = new Pizza(pizzaName, dough);

                var input = Console.ReadLine();

                while (input != "END")
                {
                    var toppingArgs = input.Split();
                    var typeTopping = toppingArgs[1];
                    var weight = double.Parse(toppingArgs[2]);

                    var topping = new Topping(typeTopping, weight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");

            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

        }
    }
}
