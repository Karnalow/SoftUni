using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public string GetRandomElement()
        {
            int index = random.Next(0, this.Count);

            return this[index];
        }

        public void RemoveRandomElement()
        {
            int index = random.Next(0, this.Count);
            RemoveAt(index);
        }
    }
}
