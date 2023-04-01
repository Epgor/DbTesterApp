using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoWorkerController : MongoGenericController<WorkerNoSql>
{
    public MongoWorkerController(GenericMongoService<WorkerNoSql> genericService)
        : base(genericService) {}
}