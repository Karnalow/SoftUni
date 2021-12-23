using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            list = new List<T>(data);
            currIndex = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in list)
            {
                yield return element;
            }
        }

        public bool HasNext() => currIndex < list.Count - 1;

        public bool MoveNext()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                currIndex++;
            }

            return canMove;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine($"{list[currIndex]}");
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(' ', list));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
