using DbTesterApp.Models.NoSql;
using DbTesterApp.Models.Sql;

namespace DbTesterApp.Services
{
    public static class DataProviderService
    {
        public static Book GetBook()
        {
            return new Book() 
            {
                Id = "",
                BookName = "invoice deliverables",
                Price = "$494,18",
                Category = "Funk",
                Author = "Cristina Stroman"
            };
        }
        public static BookNoSql GetBookNoSql()
        {
            return new BookNoSql()
            {
                Id = "",
                BookName = "invoice deliverables",
                Price = "$494,18",
                Category = "Funk",
                Author = "Cristina Stroman"
            };
        }
        public static Worker GetWorker()
        {
            return new Worker()
            {
                Id = "",
                WorkerName = "Stacey Streich",
                Salary = "8683,58",
                Category = "World",
                Address = "49037 Hillard Flat, North Evelynfurt, Luxembourg"
            };
        }
        public static WorkerNoSql GetWorkerNoSql()
        {
            return new WorkerNoSql()
            {
                Id = "",
                WorkerName = "Stacey Streich",
                Salary = "8683,58",
                Category = "World",
                Address = "49037 Hillard Flat, North Evelynfurt, Luxembourg"
            };
        }
    }
}
