using DbTesterApp.Models.NoSql;
using DbTesterApp.Models.Sql;

namespace DbTesterApp.Models
{
    public static class CollectionsDictionary
    {
        public static Dictionary<Type, string> NoSqlTypes = new Dictionary<Type, string>
        {
            { typeof(NumberNoSql), "Numbers" },
            { typeof(PointNoSql), "Points" },
            { typeof(VectorNoSql), "Vectors" },
            { typeof(WorkerNoSql), "Workers" },
            { typeof(BookNoSql), "Books" },
            { typeof(LibraryNoSql), "Libraries" },
            { typeof(OrganizationNoSql), "Organizations" }
        };
        public static Dictionary<Type, string> SqlTypes = new Dictionary<Type, string>
        {
            { typeof(Number), "Numbers" },
            { typeof(Point), "Points" },
            { typeof(Vector), "Vectors" },
            { typeof(Worker), "Workers" },
            { typeof(Book), "Books" },
            { typeof(Library), "Libraries" },
            { typeof(Organization), "Organizations" }
        };
        static Dictionary<Type, string> typeToStringMap = NoSqlTypes
            .Union(SqlTypes)
            .ToDictionary(x => x.Key, x => x.Value);
        public static string CollectionName<T>()
        {
            Type type = typeof(T);

            return typeToStringMap[type];
        }
    }
}