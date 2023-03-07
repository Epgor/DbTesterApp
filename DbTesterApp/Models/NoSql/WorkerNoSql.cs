using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class WorkerNoSql : BaseWorker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string WorkerName { get; set; }
    }
}
