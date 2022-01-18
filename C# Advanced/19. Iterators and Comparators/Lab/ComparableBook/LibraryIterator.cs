using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int index;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);

            Reset();
        }

        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            index++;

            return index < books.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
