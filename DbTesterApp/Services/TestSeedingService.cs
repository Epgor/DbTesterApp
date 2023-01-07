using Bogus;
using DbTesterApp.Models.NoSql;
using DbTesterApp.Models;
namespace DbTesterApp.Services
{
    public class TestSeedingService : ITestSeedingService
    {
        public TestSeedingService()
        {

        }

        public List<Book> SeedSql(int quantity)
        {
            Randomizer.Seed = new Random(8675309);
            int Id = 1;
            var books = new Faker<Book>()
              .RuleFor(p => p.Id, (f, p) => p.Id = (Id++).ToString())
              .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
              .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
              .Generate(quantity);
           
            //printSqlBooks(books);
            return (books);
        }

        public List<BookNoSql> SeedNoSql(int quantity)
        {
            Randomizer.Seed = new Random(8675309);
            ulong Id = 1;
            var books = new Faker<BookNoSql>()
              .RuleFor(p => p.Id, (f, p) => p.Id = (Id++).ToString())
              .RuleFor(p => p.BookName, (f, p) => f.Random.Words(2))
              .RuleFor(p => p.Author, (f, p) => f.Person.FullName)
              .RuleFor(p => p.Category, (f, p) => f.Music.Genre())
              .RuleFor(p => p.Price, (f, p) => f.Commerce.Price(1, 1000, 2, "$"))
              .Generate(quantity);

            //printSqlBooks(books);
            return (books);
        }


        private void printSqlBooks(List<Book> books)
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
