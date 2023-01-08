using Bogus;
using DbTesterApp.Models;

namespace DbTesterApp.Services
{
    public static class LibraryGenerator
    {
        public static async Task<Library> GetLibrary(
            string id,
            List<Worker> workers,
            List<Book> books,
            int quantity = 1)
        {
            var library = new Faker<Library>()
              .RuleFor(p => p.Id, (f, p) => p.Id = id)
              .RuleFor(p => p.LibraryName, (f, p) => f.Company.CompanyName())
              .RuleFor(p => p.Workers, (f, p) => p.Workers = workers)
              .RuleFor(p => p.Books, (f, p) => p.Books = books)
              .RuleFor(p => p.Address, (f, p) => f.Address.FullAddress())
              .Generate(quantity);

            return library.First();
        }
    }
}