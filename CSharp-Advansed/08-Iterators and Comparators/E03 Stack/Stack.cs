namespace E03Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> values;

        public CustomStack(params T[] values)
        {
            this.values = values.ToList();
        }

        public void Push(params T[] valuesToAdd)
        {
            this.values.AddRange(valuesToAdd);
        }

        public T Pop()
        {
            if (this.values.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            var valueToRemove = this.values[this.values.Count - 1];
            this.values.RemoveAt(this.values.Count - 1);

            return valueToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.values.Count - 1; i >= 0; i--)
            {
                yield return this.values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
