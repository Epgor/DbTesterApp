using DbTesterApp.Models.NoSql;
using DbTesterApp.Services.Redis;
using Microsoft.AspNetCore.Mvc;

namespace DbTesterApp.Controllers.Redis;

[Route("api/redis/[controller]")]
public class RedisLibraryController : RedisGenericController<LibraryNoSql>
{
    public RedisLibraryController(GenericRedisService<LibraryNoSql> genericService)
        : base(genericService) {}
}