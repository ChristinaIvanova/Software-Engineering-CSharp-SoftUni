using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> values;

        public Lake(params int[] values)
        {
            this.values = values.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.values.Count; i += 2)
            {
                yield return this.values[i];
            }

            var startIndex = (this.values.Count - 1) % 2 != 0
                ? this.values.Count - 1
                : this.values.Count - 2;

            for (int i = startIndex; i >= 0; i -= 2)
            {
                yield return this.values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
