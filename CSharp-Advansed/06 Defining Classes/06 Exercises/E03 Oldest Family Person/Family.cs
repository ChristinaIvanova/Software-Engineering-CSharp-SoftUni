﻿namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Family
    {
        private List<Person> people { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x > x.Age).FirstOrDefault();
        }
    }
}
