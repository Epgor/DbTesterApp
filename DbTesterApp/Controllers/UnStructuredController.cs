namespace DbTesterApp.Controllers;

using DbTesterApp.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UnStructuredController : ControllerBase
{
    private readonly ILogger<StructuredController> _logger;
    private readonly TestSeedingService _seeder;

    public UnStructuredController(ILogger<StructuredController> logger, TestSeedingService seedingService)
    {
        _logger = logger;
        _seeder = seedingService;
    }
    [HttpGet]
    public ActionResult TestGet([FromQuery]int quantity)
    {
        var result = _seeder.SeedNoSql(quantity);
        return Ok(result);
    }

}
