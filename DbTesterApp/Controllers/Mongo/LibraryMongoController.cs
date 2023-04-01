using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoLibraryController : MongoGenericController<LibraryNoSql>
{
    public MongoLibraryController(GenericMongoService<LibraryNoSql> genericService)
        : base(genericService) {}
}