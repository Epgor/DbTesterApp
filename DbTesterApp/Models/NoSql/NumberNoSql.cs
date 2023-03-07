using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models
{
    public class NumberNoSql : BaseNumber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
