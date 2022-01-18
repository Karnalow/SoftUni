using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> internalList = new List<T>();

        public void Add(T value)
        {
            internalList.Add(value);
        }

        public int Count
        {
            get
            {
                return internalList.Count;
            }
        }

        public T Remove()
        {
            var element = internalList[internalList.Count - 1];
            internalList.RemoveAt(internalList.Count - 1);

            return element;
        }
    }
}
