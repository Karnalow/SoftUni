using System;

namespace CustomStack
{
    public class Stack
    {
        private const int InitialCapacity = 4;

        private int[] elemets;

        public Stack()
        {
            elemets = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            Resize();


            elemets[Count++] = element;
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            int element = elemets[Count - 1];

            Count--;

            Shrink();
            
            return element;
        }

        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            int element = elemets[Count - 1];

            return element;
        }

        private void Resize()
        {
            if (Count == elemets.Length)
            {
                int[] copyArray = new int[elemets.Length * 2];

                for (int i = 0; i < elemets.Length; i++)
                {
                    copyArray[i] = elemets[i];
                }

                elemets = copyArray;
            }
        }

        private void Shrink()
        {
            if (Count <= elemets.Length / 4)
            {
                int[] tempArray = new int[elemets.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArray[i] = elemets[i];
                }

                elemets = tempArray;
            }
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < elemets.Length - 1; i++)
            {
                action(elemets[i]);
            }
        }
    }
}
