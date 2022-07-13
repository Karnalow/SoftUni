using System;

namespace CustomQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();
            queue.Dequeue();

            queue.Clear();

            queue.ForEach(x => Console.WriteLine(x));
        }
    }
}
