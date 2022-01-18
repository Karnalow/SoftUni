using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public static void SwapsElements(List<T> list, int firstElementIndex, int secondElementIndex)
        {
            T temp = list[firstElementIndex];
            list[firstElementIndex] = list[secondElementIndex];
            list[secondElementIndex] = temp;
        }
    }
}
