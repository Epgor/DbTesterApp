
namespace DbTesterApp.Models.Sql 
{
    public class BookSql: Book
    {
        public ulong Id { get; set; }

        public string ?BookName { get; set; }

        public string ?Price { get; set; }

        public string ?Category { get; set; }

        public string ?Author { get; set; }
    }
}

