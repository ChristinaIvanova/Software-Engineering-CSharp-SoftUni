using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
