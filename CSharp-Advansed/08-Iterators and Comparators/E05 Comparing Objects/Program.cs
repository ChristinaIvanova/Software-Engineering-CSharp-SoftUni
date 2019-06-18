namespace E05ComparingObjects
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var people = new List<Person>();

            while (input != "END")
            {
                var personArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);
                var town = personArgs[2];

                var person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            var personNumber = int.Parse(Console.ReadLine());

            Person personToCompare = people[personNumber - 1];

            var equalPeople = 0;
            int notEqual = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (personToCompare.CompareTo(people[i]) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equalPeople > 1)
            {
                var allPeople = people.Count;
                Console.WriteLine($"{equalPeople} {notEqual} {allPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
