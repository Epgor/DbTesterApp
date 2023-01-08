using Bogus;
using DbTesterApp.Models;

namespace DbTesterApp.Services
{
    public static class BookGenerator
    {
        public static async Task<Book> GetBook(string id, int quantity = 1)
        {
            var book = new Faker<Book>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
              .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
              .Generate(quantity);

            return book.First();
        }
    }
}