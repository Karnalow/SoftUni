namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();

            //string getBooksAgeRestriction = GetBooksByAgeRestriction(db, input);
            //string goldenBooks = GetGoldenBooks(db);
            string booksByPrice = GetBooksByPrice(db);

            //Console.WriteLine(getBooksAgeRestriction);
            //Console.WriteLine(goldenBooks);
            Console.WriteLine(booksByPrice);
        }
        
        //P02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P04
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach ( var book in books )
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
