using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    public static class Box<T>
    {
        public static void SwapsElements(List<T> list, int firstElementIndex, int secondElementIndex)
        {
            T temp = list[firstElementIndex];
            list[firstElementIndex] = list[secondElementIndex];
            list[secondElementIndex] = temp;
        }
    }
}
