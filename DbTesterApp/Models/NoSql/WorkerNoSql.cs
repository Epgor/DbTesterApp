using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class WorkerNoSql: Worker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        new public string Id { get; set; }
        [BsonElement("Name")]
        new public string WorkerName { get; set; }
    }
}
