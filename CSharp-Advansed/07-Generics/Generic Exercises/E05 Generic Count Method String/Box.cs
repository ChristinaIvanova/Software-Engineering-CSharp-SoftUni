namespace E05_Generic_Count_Method_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Box<T>
    {
        private List<T> values;

        public Box()
        {
            this.values = new List<T>();
        }

        public List<T> Values => this.values;

        public void Add(T item)
        {
            this.values.Add(item);
        }

    }
}
