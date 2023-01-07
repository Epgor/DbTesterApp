using DbTesterApp.Entities;
using DbTesterApp.Models;
namespace DbTesterApp.Services
{
    public interface IBookSqlService
    {
        public void AddTestBook(string name);
        public Book GetTestBook(string name);
    }
    public class BookSqlService : IBookSqlService
    {
        private readonly BookStoreDbContext dbContext;
        public BookSqlService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Book> GetAll()
        {
            var books = dbContext.Books.ToList();

            return books;
        }
        public void AddTestBook(string name)
        {
            var book = new Book()
            {
                Id = $"{name}asd",
                BookName = name,
                Price = "123",
                Category = "test",
                Author = "testowy"
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public Book GetTestBook(string name)
        {
            var book = dbContext.Books.First(n => n.BookName == name);

            if (book is null)
                return new Book() { BookName = "EMPTY" };

            return book;
        }
    }
}
