using DbTesterApp.Models.Sql;
using DbTesterApp.Models.NoSql;

namespace DbTesterApp.Services
{
    public interface ITestSeedingService
    {
        List<BookNoSql> SeedNoSql(int quantity);
        List<Book> SeedSql(int quantity);
    }
}