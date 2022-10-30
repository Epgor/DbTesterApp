namespace DbTesterApp.Controllers;

using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

[ApiController]
[Route("[controller]")]
public class StructuredController : ControllerBase
{
    private readonly ILogger<StructuredController> _logger;
    private readonly TestSeedingService _seeder;
    private readonly IConnectionMultiplexer _redis;

    public StructuredController(ILogger<StructuredController> logger, TestSeedingService seedingService, IConnectionMultiplexer redis)
    {
        _logger = logger;
        _seeder = seedingService;
        _redis = redis;
    }
    [HttpGet]
    public ActionResult TestGet([FromQuery]int quantity)
    {

        var result = _seeder.SeedSql(quantity);
        return Ok(result);
    }
    [HttpGet("Pong")]
    public async Task<ActionResult> Ping()
    {
        var db = _redis.GetDatabase();
        var pong = await db.PingAsync();
        await Task.Delay(new TimeSpan(0,0,2));
        return Ok($"Pong at:{pong+new TimeSpan(0,0,2)}");
    }
}
