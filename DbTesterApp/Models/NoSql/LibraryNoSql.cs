using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class LibraryNoSql : BaseLibrary
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string LibraryName { get; set; }
        public List<WorkerNoSql> Workers { get; set; }
        public List<BookNoSql> Books { get; set; }
    }
}
