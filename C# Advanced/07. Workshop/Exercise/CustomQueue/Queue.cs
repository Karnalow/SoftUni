using System;

namespace CustomQueue
{
    public class Queue
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;

        private int[] items;
        private int count;

        public Queue()
        {
            items = new int[InitialCapacity];
        }

        public void Enqueue(int element)
        {
            Resize();

            items[count] = element;

            count++;
        }

        public int Dequeue()
        {
            int firstElement = items[FirstElementIndex];

            IsEmpty();
            SwitchElements();

            count--;

            return firstElement;
        }

        public int Peek() => items[FirstElementIndex];

        public void Clear()
        {
            IsEmpty();

            int[] tempArray = new int[items.Length];

            items = tempArray;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            if (count == items.Length)
            {
                int[] tempArray = new int[items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    tempArray[i] = items[i];
                }

                items = tempArray;
            }
        }

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void SwitchElements()
        {
            items[FirstElementIndex] = default;

            for (int i = 1; i < items.Length; i++)
            {
                items[i - 1] = items[i];
            }

            items[items.Length - 1] = default;
        }
    }
}
