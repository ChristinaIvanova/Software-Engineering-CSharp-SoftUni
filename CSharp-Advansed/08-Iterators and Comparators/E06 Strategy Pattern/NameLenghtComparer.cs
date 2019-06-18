namespace E06StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class NameLenghtComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            var nameLenghtResult = first.Name.Length.CompareTo(second.Name.Length);

            if (nameLenghtResult == 0)
            {
                return first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
            }

            return nameLenghtResult;
        }
    }
}
