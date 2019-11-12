using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                //var input = int.Parse(Console.ReadLine());

                var result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            sb.Append(string.Join(Environment.NewLine, books));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            sb.Append(string.Join(Environment.NewLine, books));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input.ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            sb.Append(string.Join(Environment.NewLine, books));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var formattedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < formattedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authorsList = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            sb.Append(string.Join(Environment.NewLine, authorsList));

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            sb.Append(string.Join(Environment.NewLine, books));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            sb.Append(string.Join(Environment.NewLine, books));

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies),
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
