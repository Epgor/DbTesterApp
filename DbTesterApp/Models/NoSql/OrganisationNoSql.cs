using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DbTesterApp.Models.NoSql
{
    public class OrganisationNoSql: Organisation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        new public string Id { get; set; }
        [BsonElement("Name")]
        new public string OrganisationName { get; set; }
        new public List<LibraryNoSql> Libraries { get; set; }
        new public List<WorkerNoSql> Workers { get; set; }
    }
}
