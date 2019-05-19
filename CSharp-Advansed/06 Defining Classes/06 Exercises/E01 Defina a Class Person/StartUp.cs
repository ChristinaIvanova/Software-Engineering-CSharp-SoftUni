namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            Person firstPerson = new Person(name,age);
           
        }
    }
}
