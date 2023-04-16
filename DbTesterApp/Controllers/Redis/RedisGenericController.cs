using Microsoft.AspNetCore.Mvc;
using DbTesterApp.Services.Redis;
using DbTesterApp.Services;

namespace DbTesterApp.Controllers.Redis;

[ApiController]
public class RedisGenericController<T> : ControllerBase
{
    private readonly GenericRedisService<T> _genericService;
    private readonly HashIdentifierService _hashIdentifierService;

    public RedisGenericController(GenericRedisService<T> genericService, HashIdentifierService hashIdentifierService)
    {
        _genericService = genericService;
        _hashIdentifierService = hashIdentifierService;
    }

    [HttpPost("slow")]
    public async Task<IActionResult> PostSlow([FromBody]T Object)
    {
        var newObject = await _hashIdentifierService.SetId(Object, true);
        var result = await _genericService.AddAsync(newObject);//will return error if exist
        if (result) return Created(nameof(Post), newObject);
        return BadRequest("Uops! Something went wrong! Object creating failed!");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] T Object)
    {
        var id = await _hashIdentifierService.GetFastHashId();
        var result = await _genericService.AddAsync(Object, id);//will return error if exist
        if (result) return Created(nameof(Post), id);
        return BadRequest("Uops! Something went wrong! Object creating failed!");
    }

    [HttpPost("many")]
    public async Task<ActionResult> Post([FromBody] IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            var id = await _hashIdentifierService.GetFastHashId();
            await _genericService.AddAsync(entity, id);
        }

        return Created(nameof(Get), entities);
    }
    [HttpPost("many/fast")]
    public async Task<ActionResult> PostFast([FromBody] IEnumerable<T> entities)
    {

        var id = await _hashIdentifierService.GetFastHashId();
        await _genericService.AddFastAsync(entities, id);

        return Created(nameof(Get), entities);
    }

    [HttpGet]
    public async Task<List<T>> GetAll() 
    {
        return await _genericService.GetAllAsync();
    }
      
    [HttpGet("total")]
    public async Task<int> GetTotal()
    {
        var list = await _genericService.GetAllAsync();
        return list.Count;
    }

    [HttpGet("fast")]
    public async Task<List<string>> GetAllFast()
    {
        return await _genericService.GetAllFastAsync();
    }

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
