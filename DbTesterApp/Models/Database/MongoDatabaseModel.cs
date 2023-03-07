using DbTesterApp.Models.NoSql;
using System;
using static System.Reflection.Metadata.BlobBuilder;

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
            { typeof(NumberNoSql), "Number" }
        };

        return typeToStringMap[type];
    }
    public string BooksCollectionName { get; set; } = "Books";
    public string WorkersCollectionName { get; set; } = "Workers";
    public string NumbersCollectionName { get; set; } = "Numbers";
    public string PointsCollectionName { get; set; } = "Points";


    /*
        "LibrariesCollectionName": "Libraries",
        "OrganizationsCollectionName": "Organizations",
        "VectorsCollectionName": "Vectors",
        "PointsCollectionName": "Points",
        "NumbersCollectionName": "Numbers
    */
}
public enum NoSqlTypes
{
    NumberNoSql
}
