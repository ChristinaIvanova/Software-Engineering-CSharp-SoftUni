using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var nameInput = Console.ReadLine();
            var ageInput = int.Parse(Console.ReadLine());

            var person = new Person(nameInput, ageInput);

            Console.WriteLine(person);
        }
    }
}