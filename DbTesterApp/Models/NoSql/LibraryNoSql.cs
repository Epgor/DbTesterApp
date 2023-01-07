using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class LibraryNoSql: Library
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        new public string Id { get; set; }

        [BsonElement("Name")]
        new public string LibraryName { get; set; }
        new public List<WorkerNoSql> Workers { get; set; }
        new public List<BookNoSql> Books { get; set; }
    }
}
