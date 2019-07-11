using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                var peopleInput = Console.ReadLine()
                                 .Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);

                var productInput = Console.ReadLine()
                                  .Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);

                var people = GetPeople(peopleInput);
                var products = GetProducts(productInput);

                var command = Console.ReadLine();

                while (command != "END")
                {
                    var commandArgs = command.Split();

                    var personName = commandArgs[0];
                    var productItem = commandArgs[1];

                    var person = people.FirstOrDefault(p => p.Name == personName);
                    var product = products.FirstOrDefault(p => p.Name == productItem);

                    Console.WriteLine(person.AddProduct(product));

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    var productsBought = person.Products.Count == 0 ? "Nothing bought"
                        : string.Join(", ", person.Products.Select(p => p.Name));

                    Console.WriteLine($"{person.Name} - {productsBought}");
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }

        private static List<Person> GetPeople(string[] peopleInput)
        {
            var list = new List<Person>();

            for (int i = 0; i < peopleInput.Length; i += 2)
            {
                var personName = peopleInput[i];
                var personMoney = decimal.Parse(peopleInput[i + 1]);

                var person = new Person(personName, personMoney);
                list.Add(person);
            }

            return list;
        }

        private static List<Product> GetProducts(string[] productInput)
        {
            var list = new List<Product>();

            for (int i = 0; i < productInput.Length; i += 2)
            {
                var productName = productInput[i];
                var productCost = decimal.Parse(productInput[i + 1]);

                var product = new Product(productName, productCost);
                list.Add(product);
            }

            return list;
        }
    }
}
