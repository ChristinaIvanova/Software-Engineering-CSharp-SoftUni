namespace Workshop_Create_List
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public void Add(int value)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = value;
            this.Count++;
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public int RemoveAt(int index)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);

            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public void Insert(int index, int value)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = value;
            this.Count--;
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public bool Contains(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.items[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var firstValue = this.items[firstIndex];
            var secondVaue = this.items[secondIndex];

            this.items[firstIndex] = secondVaue;
            this.items[secondIndex] = firstValue;
        }
    }
}
