using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var listOfInt = new DoublyLinkedList<int>();

            listOfInt.AddFirst(3);
            // 3
            listOfInt.AddFirst(2);
            // 2-3
            listOfInt.AddFirst(1);
            // 1-2-3
            listOfInt.AddLast(4);
            // 1-2-3-4
            listOfInt.AddFirst(0);
            // 0-1-2-3-4
            listOfInt.AddLast(100);
            // 0-1-2-3-4-100
            listOfInt.RemoveFirst();
            // 1-2-3-4-100
            listOfInt.RemoveLast();
            // 1-2-3-4
            listOfInt.AddLast(5);
            // 1-2-3-4-5

            Console.WriteLine(String.Join('-', listOfInt.ToArray()));
            // 1, 2, 3, 4, 5

            listOfInt.ForEach(x => Console.WriteLine(x));

            var listOfStrings = new DoublyLinkedList<string>();

            listOfStrings.AddLast("Ivan");
            listOfStrings.AddFirst("Hristo");
            listOfStrings.RemoveLast();

            listOfStrings.ForEach(x => Console.WriteLine(x));
        }
    }
}
