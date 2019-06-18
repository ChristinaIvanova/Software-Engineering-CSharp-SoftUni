namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
       => this.GetEnumerator();

        private class LibraryEnumerator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryEnumerator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }

            public Book Current
            {
                get
                {
                    return this.books[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;

                if (index < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
