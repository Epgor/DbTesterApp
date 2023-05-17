using DbTesterApp.Models.NoSql;
using DbTesterApp.Services;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisPointController : RedisGenericController<PointNoSql>
{
    public RedisPointController(GenericRedisService<PointNoSql> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}