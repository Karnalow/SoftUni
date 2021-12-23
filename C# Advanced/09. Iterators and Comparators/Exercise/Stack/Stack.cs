using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;

        public Stack(params T[] data)
        {
            list = new List<T>(data);
        }

        public void Push(params T[] elements)
        {
            foreach (var currelement in elements)
            {
                list.Insert(list.Count, currelement);
            }
        }
        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T element = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
