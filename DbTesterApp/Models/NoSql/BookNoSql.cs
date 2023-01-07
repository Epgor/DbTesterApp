using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DbTesterApp.Models.NoSql 
{
    public class BookNoSql: Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        new public string Id { get; set; }

        [BsonElement("Name")]
        new public string BookName { get; set; }
    }
}

