using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoVectorController : MongoGenericController<VectorNoSql>
{
    public MongoVectorController(GenericMongoService<VectorNoSql> genericService)
        : base(genericService) {}
}