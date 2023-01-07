using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models
{
    public class PointNoSql: Point
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        new public string Id { get; set; }
        [BsonElement("Name")]
        new public string Name { get; set; }
        new public List<NumberNoSql> Values { get; set; }
    }
}
