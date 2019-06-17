namespace E03_Generic_Swap_Method_Strings
{
    using System;
    using System.Collections.Generic;
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

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.values[firstIndex];
            this.values[firstIndex] = this.values[secondIndex];
            this.values[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in values)
            {
                sb.AppendLine($"{typeof(T)} {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
