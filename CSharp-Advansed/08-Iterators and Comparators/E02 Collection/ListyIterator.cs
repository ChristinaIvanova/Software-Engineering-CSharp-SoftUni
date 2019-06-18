﻿namespace E02ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;


    public class ListyIterator<T>: IEnumerable<T>
    {
        private List<T> values;
        private int index = 0;

        public ListyIterator(List<T> values)
        {
            this.values = values;
        }
        
        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.values.Count==0)
            {
                return "Invalid Operation!";
            }

            return this.values[index].ToString();
        }

        public bool HasNext()
        {
            if (index < this.values.Count - 1)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.values.Count; i++)
            {
                yield return this.values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
         => this.GetEnumerator();
    }
}
