using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Library library = new Library();

            library.Add(new Book("Don Quixote", 1605, new List<string>() { "Maguel de Cervantes" }));
            library.Add(new Book("Lord of the Rings", 20015, new List<string>() { "J.R.R. Tolkien" }));
            library.Add(new Book("Harry Potter and the Sorcerer's Stone", 2006, new List<string>() { "J.K. Rowling" }));
            library.Add(new Book("And Then There Were None", 1997, new List<string>() { "Agatha Christie" }));
            library.Add(new Book("Alice's Adventures in Wonderland", 2004, new List<string>() { "Lewis Carroll" }));
            library.Add(new Book("The Lion, the Witch, and the Wardrobe", 1605, new List<string>() { "C.S. Lewis" }));

            foreach (var book in library)
            {
                Console.WriteLine($"{string.Join('&', book.Authors)} - {book.Title} ({book.Year})");
            }
        }
    }
}
