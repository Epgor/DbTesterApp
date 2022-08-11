using Bogus;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Models.Sql;
namespace DbTesterApp.Services
{
    public class TestSeedingService : ITestSeedingService
    {
        public TestSeedingService()
        {

        }

        public void SeedSql()
        {
            Randomizer.Seed = new Random(8675309);
            ulong Id = 0;
            var books = new Faker<BookSql>()
              .RuleFor(p => p.Id, (f, p) => p.Id = Id++)
              .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
              .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
              .Generate(10);
           
            printSqlBooks(books);
        }

        public void SeedNoSql()
        {
            Randomizer.Seed = new Random(8675309);
            ulong Id = 0;
            var books = new Faker<BookNoSql>()
              .RuleFor(p => p.Id, (f, p) => p.Id = Id++)
              .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
              .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
              .Generate(10);

            printSqlBooks(books);
        }


        private void printSqlBooks(List<BookSql> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.Id);
                Console.WriteLine(book.BookName);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Category);
                Console.WriteLine(book.Price);
                Console.WriteLine("----------------------------");
            }
        }
        private void printSqlBooks(List<BookNoSql> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book.Id);
                Console.WriteLine(book.BookName);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.Category);
                Console.WriteLine(book.Price);
                Console.WriteLine("----------------------------");
            }
        }


    }



}
