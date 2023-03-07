using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class OrganizationNoSql : BaseOrganization
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string OrganizationName { get; set; }
        public List<LibraryNoSql> Libraries { get; set; }
        public List<WorkerNoSql> Workers { get; set; }
    }
}
