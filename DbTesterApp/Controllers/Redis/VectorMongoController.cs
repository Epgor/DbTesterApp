using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class VectorController : RedisGenericController<VectorNoSql>
{
    public VectorController(GenericRedisService<VectorNoSql> genericService)
        : base(genericService) {}
}