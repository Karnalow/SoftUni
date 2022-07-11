using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private LinkedListItem<T> first = null;
        private LinkedListItem<T> last = null;

        public int Count
        {
            get
            {
                int count = 0;

                var current = first;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public void AddFirst(T element)
        {
            var newItem = new LinkedListItem<T>(element);

            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previous = newItem;

                first = newItem;
            }
        }

        public void AddLast(T element)
        {
            var newItem = new LinkedListItem<T>(element);

            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Previous = last;
                last.Next = newItem;

                last = newItem;
            }
        }

        public T RemoveFirst()
        {
            if (first == null) // 0 items
            {
                throw new InvalidOperationException("Linked list empty!");
            }

            var currentFirstValue = first.Value;

            if (first == last) // 1 item
            {
                first = null;
                last = null;
            }
            else // more than 1 item
            {
                var newFirst = first.Next;
                newFirst.Previous = null;

                first = newFirst;
            }

            return currentFirstValue;
        }

        public T RemoveLast()
        {
            if (first == null) // 0 items
            {
                throw new InvalidOperationException("Linked list empty!");
            }

            var currentLasrValue = last.Value;

            if (first == last) // 1 item
            {
                first = null;
                last = null;
            }
            else // more than 1 item
            {
                var newLast = last.Previous;
                newLast.Next = null;

                last = newLast;
            }

            return currentLasrValue;
        }

        public void ForEach(Action<T> action)
        {
            var current = first;

            while (current != null)
            {
                action(current.Value);

                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[Count];

            var current = first;
            var index = 0;

            while (current != null)
            {
                array[index] = current.Value;
                index++;

                current = current.Next;
            }

            return array;
        }
    }
}
