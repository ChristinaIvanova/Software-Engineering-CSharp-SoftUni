namespace DefiningClasses
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var countMember = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < countMember; i++)
            {
                var personArgs = Console.ReadLine().Split();

                var name = personArgs[0];
                var age = int.Parse(personArgs[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            var membersOverThirty = family.GetMembersOverThirty();
            Console.WriteLine(string.Join(Environment.NewLine,membersOverThirty));
            //foreach (var member in membersOverThirty)
            //{
            //    Console.WriteLine(member);
            //}

        }
    }
}
