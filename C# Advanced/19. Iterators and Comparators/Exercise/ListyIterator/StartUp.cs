using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;

            ListyIterator<string> listy = null;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (token[0] == "Create")
                {
                    listy = new ListyIterator<string>(token.Skip(1).ToArray());
                }
                else if (token[0] == "Move")
                {
                    Console.WriteLine(listy.MoveNext());
                }
                else if (token[0] == "Print")
                {
                    listy.Print();
                }
                else if (token[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
            }
        }
    }
}
