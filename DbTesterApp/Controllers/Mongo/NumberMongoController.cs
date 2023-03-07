using DbTesterApp.Models;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class NumbersController : MongoGenericController<NumberNoSql>
{
    public NumbersController(GenericNoSqlService<NumberNoSql> genericService) : base(genericService)
    {
    }
}