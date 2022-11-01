namespace DbTesterApp.Controllers;

using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

[ApiController]
[Route("[controller]")]
public class StructuredController : ControllerBase
{
    private readonly TestSeedingService _seeder;
    public StructuredController(TestSeedingService seedingService)
    {
        _seeder = seedingService;
    }
    [HttpGet]
    public ActionResult TestGet([FromQuery]int quantity)
    {

        var result = _seeder.SeedSql(quantity);
        return Ok(result);
    }

}
