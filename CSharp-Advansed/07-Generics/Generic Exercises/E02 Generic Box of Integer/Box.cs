﻿namespace E02_Generic_Box_of_Integer
{
    class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{item.GetType()} {item}";
        }
    }
}