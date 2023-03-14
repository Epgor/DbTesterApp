using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Mongo;

[Route("api/mongo/[controller]")]
public class MongoOrganizationController : MongoGenericController<OrganizationNoSql>
{
    public MongoOrganizationController(GenericNoSqlService<OrganizationNoSql> genericService)
        : base(genericService) {}
}