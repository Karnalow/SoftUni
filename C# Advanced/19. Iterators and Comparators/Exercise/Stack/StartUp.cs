using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                string[] token = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "END")
                {
                    break;
                }
                else if (token[0] == "Push")
                {
                    stack.Push(token.Skip(1).Select(e => e.Split(',').First()).ToArray());
                }
                else if (token[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
