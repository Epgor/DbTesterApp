using DbTesterApp.Models.NoSql;
using DbTesterApp.Services;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisOrganizationController : RedisGenericController<OrganizationNoSql>
{
    public RedisOrganizationController(GenericRedisService<OrganizationNoSql> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}