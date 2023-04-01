using Microsoft.AspNetCore.Mvc;
using DbTesterApp.Services.Redis;

namespace DbTesterApp.Controllers.Redis;

[ApiController]
public class RedisGenericController<T> : ControllerBase
{
    private readonly GenericRedisService<T> _genericService;

    public RedisGenericController(GenericRedisService<T> genericService)
    {
        _genericService = genericService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(T newObject)
    {
        var result = await _genericService.AddAsync(newObject);//will return error if exist
        if (result) return CreatedAtAction(nameof(Post), newObject);
        return BadRequest("Uops! Something went wrong! Object creating failed!");
    }

    [HttpGet]
    public async Task<List<T>> GetAll() =>
      await _genericService.GetAllAsync();

    [HttpGet("fast")]
    public async Task<List<string>> GetAllFast() =>
    await _genericService.GetAllFastAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<T>> Get(string id)
    {
        var value = await _genericService.GetAsync(id);

        if (value is null)
        {
            return NotFound();
        }

        return value;
    }
    [HttpGet("{id:length(24)}/fast")]
    public async Task<ActionResult<string>> GetFast(string id)
    {
        var value = await _genericService.GetFastAsync(id);

        if (value is null)
        {
            return NotFound();
        }

        return value;
    }
    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, T updatedNumber)
    {
        var keyExist = await _genericService.KeyExist(id);

        if (!keyExist)
        {
            return NotFound();
        }

        await _genericService.UpdateAsync(id, updatedNumber);

        return NoContent();
    }
    
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var keyExist = await _genericService.KeyExist(id);

        if (!keyExist)
        {
            return NotFound();
        }

        await _genericService.DeleteAsync(id);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete()
    {

        await _genericService.DeleteAllAsync();

        return NoContent();
    }

    [HttpGet("Pong")]
    public async Task<ActionResult> Ping()
    {
        var result = await _genericService.HealthCheck();
        return Ok(result);
    }
}
