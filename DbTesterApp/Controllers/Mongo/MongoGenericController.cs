using DbTesterApp.Services;
using DbTesterApp.Services.Mongo;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;

namespace DbTesterApp.Controllers.Mongo;

[ApiController]
public class MongoGenericController<T> : ControllerBase
{
    private readonly GenericMongoService<T> _genericService;
    private readonly HashIdentifierService _hashIdentifierService;

    public MongoGenericController(GenericMongoService<T> genericService, HashIdentifierService hashIdentifierService)
    {
        _genericService = genericService;
        _hashIdentifierService = hashIdentifierService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] T entity)
    {
        var newEntity = await _hashIdentifierService.SetId(entity, true);
        await _genericService.CreateAsync(newEntity);

        return Created(nameof(Get), newEntity);
    }

    [HttpPost("full")]
    public async Task<IActionResult> PostFull([FromBody] T entity)
    {
        await _genericService.CreateAsync(entity);

        return Created(nameof(Get), entity);
    }

    [HttpPost("many")]
    public async Task<ActionResult> Post([FromBody] IEnumerable<T> entities)
    {
        var newEntities = new List<T>();

        foreach (var entity in entities)
        {
            var newEntity = await _hashIdentifierService.SetId(entity, true);
            newEntities.Add(newEntity);
        }

        await _genericService.CreateManyAsync(newEntities);

        return Created(nameof(Get), newEntities);
    }

    [HttpGet("total")]
    public async Task<ActionResult> total() 
    {
        var list = await _genericService.GetAsync();
        var total = list.Count;
        return Ok(total);
    }

    [HttpGet]
    public async Task<List<T>> GetAll()
    {
        return await _genericService.GetAsync();
    }  

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<T>> Get(string id)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] T updatedNumber)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _genericService.UpdateAsync(id, updatedNumber);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _genericService.GetAsync(id);

        if (book is null)
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
    [HttpGet("ids")]
    public async Task<List<string>> GetAllIds()
    {
        List<string> ids = await _genericService.GetAllIds();
        return ids;
    }
    [HttpGet("testdelete")]
    public async Task<IActionResult> TestDelete()
    {
        await _genericService.DeleteSomeId();
        return Ok();
    }
    [HttpGet("generate/{num}")]
    public async Task<IActionResult> GenerateVolume([FromRoute] int num=1)
    {
        for (int i = 0; i < num; i++)
        {
            await _hashIdentifierService.GetHashId();
        }
        return Ok();
    }
}