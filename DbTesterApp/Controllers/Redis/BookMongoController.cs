using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisBookController : RedisGenericController<BookNoSql>
{
    public RedisBookController(GenericRedisService<BookNoSql> genericService)
        : base(genericService) {}
}