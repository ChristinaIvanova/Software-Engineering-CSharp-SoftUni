namespace IteratorsAndComparators
{
    using System.Collections.Generic;

    public class BookComparer : IComparer<Book>
    {
        private Book[] books;

        public BookComparer(Book[] books)
        {
            this.books = books;
        }

        public int Compare(Book first, Book second)
        {
            var titleCompare = first.Title.CompareTo(second.Title);

            if (titleCompare == 0)
            {
                //return first.Year.CompareTo(second.Year);
                return second.Year - first.Year;
            }

            return titleCompare;
        }
    }
}
