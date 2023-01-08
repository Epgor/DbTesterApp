using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace DbTesterApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookRedisController : ControllerBase
{

    private readonly IConnectionMultiplexer _redis;

    public BookRedisController(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    [HttpGet("Pong")]
    public async Task<ActionResult> Ping()
    {
        var db = _redis.GetDatabase();
        var pong = await db.PingAsync();
        await Task.Delay(new TimeSpan(0, 0, 2));//for future performance improvement
        return Ok($"Pong at:{pong + new TimeSpan(0, 0, 2)}");
    }
}
