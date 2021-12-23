using System;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int currIndex;

        public ListyIterator(params T[] data)
        {
            list = new List<T>(data);
            currIndex = 0;
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
    }
}
