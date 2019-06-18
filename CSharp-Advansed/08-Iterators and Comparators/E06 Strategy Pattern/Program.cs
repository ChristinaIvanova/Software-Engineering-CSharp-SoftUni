namespace E06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            var sortByName = new SortedSet<Person>(new NameLenghtComparer());
            var sortByAge = new SortedSet<Person>(new AgeComparer());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personArgs = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);

                var person = new Person(name, age);

                sortByName.Add(person);
                sortByAge.Add(person);
            }

            foreach (var person in sortByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
