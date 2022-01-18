using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void AddMethod(T element)
        {
            list.Add(element);
        }

        public int CountMethodString(T value)
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
