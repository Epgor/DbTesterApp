using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisNumberController : RedisGenericController<NumberNoSql>
{
    public RedisNumberController(GenericRedisService<NumberNoSql> genericService)
        : base(genericService) {}
}