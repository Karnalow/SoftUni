namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //--Inputs
            //string input = Console.ReadLine();
            //int input = int.Parse(Console.ReadLine());

            //--Methods
            //string getBooksAgeRestriction = GetBooksByAgeRestriction(db, input);
            //string goldenBooks = GetGoldenBooks(db);
            //string booksByPrice = GetBooksByPrice(db);
            //string notReleasedIn = GetBooksNotReleasedIn(db, year);
            //string bookTitlesByCategory = GetBooksByCategory(db, input);
            //string releasedBeforeDate = GetBooksReleasedBefore(db, input);
            //string authorSearch = GetAuthorNamesEndingIn(db, input);
            //string bookSearch = GetBookTitlesContaining(db, input);
            //string bookSearchByAuthor = GetBooksByAuthor(db, input);
            //int countBooks = CountBooks(db, input);
            //string totalBookCopies = CountCopiesByAuthor(db);
            //string profitByCategory = GetTotalProfitByCategory(db);
            //string mostRecentBooks = GetMostRecentBooks(db);
            int removeBooks = RemoveBooks(db);

            //--Outputs
            //Console.WriteLine(getBooksAgeRestriction);
            //Console.WriteLine(goldenBooks);
            //Console.WriteLine(booksByPrice);
            //Console.WriteLine(notReleasedIn);
            //Console.WriteLine(bookTitlesByCategory);
            //Console.WriteLine(releasedBeforeDate);
            //Console.WriteLine(authorSearch);
            //Console.WriteLine(bookSearch);
            //Console.WriteLine(bookSearchByAuthor);
            //Console.WriteLine(countBooks);
            //Console.WriteLine(totalBookCopies);
            //Console.WriteLine(profitByCategory);
            //Console.WriteLine(mostRecentBooks);
            Console.WriteLine(removeBooks);
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

        //P05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split().ToList();

            List<string> books = context.Books
                .Where(x => x.BookCategories.Any(b => categories.Contains(b.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < inputDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //P09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })         
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //P11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        //P12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //P13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoryProfits = context.Categories
                .Select(cp => new
                {
                    cp.Name,
                    TotalProfit = cp.CategoryBooks
                                    .Select(cb => new
                                    {
                                        BookProfit = cb.Book.Price * cb.Book.Copies
                                    })
                                    .Sum(cb => cb.BookProfit)
                })
                .OrderByDescending(cp => cp.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var category in categoryProfits)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookReleaseDate = cb.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.BookReleaseDate)
                    .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //P15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books) 
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //P16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);

            int count = booksToDelete.Count();

            foreach(var book in booksToDelete)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }
    }
}
