using DbTesterApp.Models.NoSql;
namespace DbTesterApp.Models.Database;

public class MongoDatabaseModel
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName<T>() 
    {
        Type type = typeof(T);

        Dictionary<Type, string> typeToStringMap = new Dictionary<Type, string>
        {
            { typeof(NumberNoSql), "Number" },
            { typeof(PointNoSql), "Point" },
            { typeof(VectorNoSql), "Vector" },
            { typeof(WorkerNoSql), "Worker" },
            { typeof(BookNoSql), "Book" },
            { typeof(LibraryNoSql), "Library" },
            { typeof(OrganizationNoSql), "Organization" }
        };

        return typeToStringMap[type];
    }
}
public enum NoSqlTypes
{
    NumberNoSql,
    PointNoSql,
    VectorNoSql,
    WorkerNoSql,
    BookNoSql,
    LibraryNoSql,
    OrganizationNoSql
}
