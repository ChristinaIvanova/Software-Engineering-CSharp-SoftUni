using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int MinValue = 12;
        private const int MaxValue = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRangeAttribute(MinValue, MaxValue)]
        public int Age { get; private set; }
    }
}
