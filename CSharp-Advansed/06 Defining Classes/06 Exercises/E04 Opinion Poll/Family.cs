namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Family
    {
        private List<Person> people { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public List<Person> GetMembersOverThirty()
        {
            return this.people.Where(x => x.Age >= 30)
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
