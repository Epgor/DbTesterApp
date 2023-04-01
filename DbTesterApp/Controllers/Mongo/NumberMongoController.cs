using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoNumberController : MongoGenericController<NumberNoSql>
{
    public MongoNumberController(GenericMongoService<NumberNoSql> genericService)
        : base(genericService) {}
}