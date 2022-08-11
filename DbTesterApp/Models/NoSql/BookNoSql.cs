
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DbTesterApp.Models.NoSql 
{
    public class BookNoSql :Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ulong Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } = null!;

        public string? Price { get; set; }

        public string Category { get; set; } = null!;

        public string Author { get; set; } = null!;
    }
}

