using DbTesterApp.Entities;
using DbTesterApp.Models.Sql;

namespace DbTesterApp.Services
{
    public interface IBookSqlService
    {
        public void AddTestBook(string name);
        public BookSql GetTestBook(string name);
    }
    public class BookSqlService : IBookSqlService
    {
        private readonly BookStoreDbContext dbContext;
        public BookSqlService(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<BookSql> GetAll()
        {
            var books = dbContext.Books.ToList();

            return books;
        }
        public void AddTestBook(string name)
        {
            var book = new BookSql()
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

        public BookSql GetTestBook(string name)
        {
            var book = dbContext.Books.First(n => n.BookName == name);

            if (book is null)
                return new BookSql() { BookName = "EMPTY" };

            return book;
        }
    }
}
