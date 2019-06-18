namespace E07EqualityLogic
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var hashPeople = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            for (int i = 0; i < lines; i++)
            {
                var personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);

                var person = new Person(name, age);

                hashPeople.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(hashPeople.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
