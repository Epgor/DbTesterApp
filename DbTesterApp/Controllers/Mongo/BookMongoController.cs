using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoBookController : MongoGenericController<BookNoSql>
{
    public MongoBookController(GenericMongoService<BookNoSql> genericService) 
        : base(genericService) {}
}