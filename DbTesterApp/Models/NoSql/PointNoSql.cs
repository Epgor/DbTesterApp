using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models
{
    public class PointNoSql : BasePoint
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public List<NumberNoSql> Values { get; set; }
    }
}
