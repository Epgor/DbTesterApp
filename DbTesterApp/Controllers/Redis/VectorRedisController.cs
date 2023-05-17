using DbTesterApp.Models.NoSql;
using DbTesterApp.Services;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisVectorController : RedisGenericController<VectorNoSql>
{
    public RedisVectorController(GenericRedisService<VectorNoSql> genericService,
                                HashIdentifierService hashIdentifierService)
        : base(genericService, hashIdentifierService) { }
}