using DbTesterApp.Models.NoSql;
namespace DbTesterApp.Models.Database;

public class MongoDatabaseModel
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}